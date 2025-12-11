using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entites
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSectionId, string name, string description)
            : base(menuSectionId)
        {
                Name = name;
                Description = description;
        }

        public static MenuSection Create(string name, string description, List<MenuItem> items)
        {
            //return new MenuSection(
            //    MenuSectionId.CreateUnique(),
            //    name,
            //    description);

            // GPT answer - to resolve tutorial mistamtch problem

            var section = new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description);

            section._items.AddRange(items);

            return section;
        }

        private MenuSection()
        {
            // For EFCore
        }

    }
}
