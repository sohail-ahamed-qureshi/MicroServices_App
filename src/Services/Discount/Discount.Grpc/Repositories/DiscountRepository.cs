using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Discount.Grpc.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            //connection.Open();
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("Select * From Coupon Where ProductName = @ProductName", new { ProductName = productName });
            //connection.Close();
            if (coupon == null)
                return new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount" };
            return coupon;


        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            connection.Open();
            var affected = await connection.ExecuteAsync("Insert into coupon (ProductName, Description, Amount)values(@ProductName,@Description, @Amount )", new { ProductName = coupon.ProductName, Amount = coupon.Amount, Description = coupon.Description });
            connection.Close();
            if (affected == 0)
                return false;
            return true;

        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            connection.Open();
            var affected = await connection.ExecuteAsync("Update coupon set ProductName = @ProductName, Description = @Description, Amount = @Amount Where Id = @Id", new { Id = coupon.Id, ProductName = coupon.ProductName, Amount = coupon.Amount, Description = coupon.Description });
            connection.Close();
            if (affected == 0)
                return false;
            return true;

        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            connection.Open();
            var affected = await connection.ExecuteAsync("Delete  from coupon where ProductName = @ProductName", new { ProductName = productName });
            connection.Close();
            if (affected == 0)
                return false;
            return true;

        }
    }
}
