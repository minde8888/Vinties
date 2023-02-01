

using Vinties.Domain.Models;
using Vinties.Services.Discount;
using Vinties.Services.Services;

namespace Tests.Services
{
    public class ReadWriteTextFileTests
    {
        private readonly FileService _fileService;

        public ReadWriteTextFileTests()
        {
            _fileService = new FileService();
        }

        [Fact]
        public async Task ReadInput_ShouldReturnListOfGoodsDelivery()
        {
            var fileService = new FileService();

            var result = await fileService.ReadInput();

            Assert.NotEmpty(result);
            Assert.IsType<List<GoodsDelivery>>(result);
        }

        [Fact]
        public async Task ReadFilePices_ShouldReturnStringArray()
        {
            var result = await _fileService.ReadInput();

            Assert.NotEmpty(result);
            Assert.IsType<string[]>(result);
        }

        [Fact]
        public void WriteFile_ShouldWriteToFile()
        {
            var fileService = new FileService();
            var list = new List<GoodsDelivery>
            {
                new GoodsDelivery {Date = DateTime.Now, Company = "Test1", Size = "A", Price = 10, Discount = 2},
                new GoodsDelivery {Date = DateTime.Now, Company = "Test2", Size = "B", Price = 20, Discount = 5}
            };

            fileService.WriteFile(list);

            Assert.True(File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Vinties1.txt")));
        }

    }   
}
