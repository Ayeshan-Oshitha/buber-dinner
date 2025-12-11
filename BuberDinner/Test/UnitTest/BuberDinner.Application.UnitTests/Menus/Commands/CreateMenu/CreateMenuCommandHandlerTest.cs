using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTest
    {
        private readonly CreateMenuCommandHandler _handler;
        private readonly Mock<IMenuRepository> _mockMenuRepository;

        public CreateMenuCommandHandlerTest()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
        }

        // T1_T2_T3
        // T1 : System Under Test (SUT) - logical component we're testing
        // T2 : Scenario - what we're testing
        // T3 : Expected Outcome - what we expect logical component to do

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommands))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu()
        {
            // Arrange - Get hold of a valid Menu
            var createMenuCommand = CreateMenuCommandUtils.CreateCommand();

            // Act - Invoke the handler
            var result = await _handler.Handle(createMenuCommand, default);

            // Assert 
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedFrom(createMenuCommand);
            _mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once);

            // 1. Validate correct menu created based on command
            // 2. Menu added to repository
        }

        public static IEnumerable<object[]> ValidCreateMenuCommands()
        {
            yield return new object[] { CreateMenuCommandUtils.CreateCommand() };

            yield return new object[] { CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateMenuSectionsCommand(sectionCount: 3)
                ) };

            yield return new object[] { CreateMenuCommandUtils.CreateCommand(
                sections: CreateMenuCommandUtils.CreateMenuSectionsCommand(
                    sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateMenuItemsCommand(itemCount: 3)
                    )
                ) };

        }
    }
}
