﻿using AutoMapper;
using MyCleanProject1.Application.Contracts.Persistence;
using MyCleanProject1.Application.Features.Categories.Commands.CreateCategory;
using MyCleanProject1.Application.Profiles;
using MyCleanProject1.Application.Responses;
using MyCleanProject1.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MyCleanProject1.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;
        private readonly Mock<IMessageRepository> _mockMessageRepository;

        public CreateCategoryTests()
        {
            _mockCategoryRepository = CategoryRepositoryMocks.GetCategoryRepository();
            _mockMessageRepository = MessageRepositoryMocks.GetMessageRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoryRepository()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object, _mockMessageRepository.Object);

            var result = await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

            result.ShouldBeOfType<Response<CreateCategoryDto>>();
            result.Succeeded.ShouldBe(true);
            result.Errors.ShouldBeNull();
            allCategories.Count.ShouldBe(5);
        }

        [Fact]
        public async Task Handle_EmptyCategory_AddedToCategoryRepository()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object, _mockMessageRepository.Object);

            var result = await Should.ThrowAsync<Exceptions.ValidationException>(() => handler.Handle(new CreateCategoryCommand() { Name = "" }, CancellationToken.None));

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

            allCategories.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Handle_CategoryLength_GreaterThan_10_AddedToCategoryRepository()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object, _mockMessageRepository.Object);

            var result = await Should.ThrowAsync<Exceptions.ValidationException>(() => handler.Handle(new CreateCategoryCommand() { Name = "TEST123456780" }, CancellationToken.None));

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(4);
        }
    }
}
