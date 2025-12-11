using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Constants;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils
{
    public static class CreateMenuCommandUtils
    {
        public static CreateMenuCommand CreateCommand(
            List<MenuSectionCommand>? sections = null
            ) =>
            new CreateMenuCommand(
                Constants.Host.Id.ToString()!,
                Constants.Menu.Name,
                Constants.Menu.Description,
                sections ?? CreateMenuSectionsCommand()
                );

        public static List<MenuSectionCommand> CreateMenuSectionsCommand(
            int sectionCount = 2,
            List<MenuItemCommand>? items = null) 
            =>
            Enumerable.Range(0, sectionCount)
            .Select(index => new MenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                items ?? CreateMenuItemsCommand()
                )).ToList();

        public static List<MenuItemCommand> CreateMenuItemsCommand(int itemCount = 2) =>
            Enumerable.Range(0, itemCount)
            .Select(index => new MenuItemCommand(
                Constants.Menu.ItemNameFromIndex(index),
                Constants.Menu.ItemDescriptionFromIndex(index)
                )).ToList();
    }
}
