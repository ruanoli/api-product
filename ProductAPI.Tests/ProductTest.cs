using Azure.Core;
using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using ProductAPI.Data.Entities;
using ProductAPI.Services.Helpers;
using ProductAPI.Services.Models;
using ProductAPI.Services.Models.Enums;
using ProductAPI.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductAPI.Tests
{
    public class ProductTest
    {
        private const string endPoint = "/api/products";

        [Fact]
        public async Task Product_Post_Returns_Created()
        {
            await CreateProduct();
        }

        [Fact]
        public async Task Product_Update_Returns_Ok()
        {
            //Cria o produto em memoria para edita-lo
            var product = await CreateProduct();

            var faker = new Faker("pt_BR");

            var request = new ProductUpdateRequestModel
            {
                Id = product.Id,
                Name = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Price = decimal.Parse(faker.Commerce.Price(2)),
                Quantity = faker.Random.Int(1, 100)
            };

            var result = await TestHelper.CreateClient().PutAsync(endPoint + "/UpdateProduct", TestHelper.CreateContent(request));

            //verificando se o resultado do teste passou 
            //para passar o resultado obtido deve ser 200.
            result.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            //Desserializa o retorno obtido pela API.
            var response = TestHelper.ReadResponse<ProductResponseModel>(result);

            //verificações
            response.StatusCode.Should().Be(200);
            response.Message.Should().Be(MessageManager.ControllMessage(MessageEnum.SuccessUpdate, "Produto"));
            response.Product.Should().NotBeNull();
        }

        [Fact(Skip = "Não implementado.")]
        public void Product_Delete_Returns_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Product_GetById_Returns_Ok()
        {

        }

        [Fact(Skip = "Não implementado.")]
        public void Product_GetAll_Returns_Ok()
        {

        }

        private async Task<Product> CreateProduct()
        {
            //criando dados faker para cadastrar produtos
            var faker = new Faker("pt_BR");
            var request = new ProductPostRequestModel
            {
                Name = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                Price = decimal.Parse(faker.Commerce.Price(2)),
                Quantity = faker.Random.Int(1, 100)
            };

            var result = await TestHelper.CreateClient().PostAsync(endPoint + "/RegisterProduct", TestHelper.CreateContent(request));

            //verificando se o resultado do teste passou 
            //para passar o resultado obtido deve ser 201.
            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            //Desserializa o retorno obtido pela API.
            var response = TestHelper.ReadResponse<ProductResponseModel>(result);

            //verificações
            response.StatusCode.Should().Be(201);
            response.Message.Should().Be(MessageManager.ControllMessage(MessageEnum.SuccessRegister, "Produto"));
            response.Product.Should().NotBeNull();

            return response.Product;
        }
    }
}
