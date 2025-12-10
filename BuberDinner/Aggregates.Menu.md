# Domain Models

## Menu

```csharp
class Menu
{
  Menu create();
  void AddDinner(Dinner dinner);
  void RemoveDinner(Dinner dinner);
  void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Italian Delight",
  "description": "A delightful selection of classic Italian dishes.",
  "averageRating": 4.5,
  "sections": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Bruschetta",
          "description": "Grilled bread topped with fresh tomatoes, garlic, and basil.",
          "price": 6.99
        },
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Caprese Salad",
          "description": "Fresh mozzarella, tomatoes, and basil drizzled with balsamic glaze.",
          "price": 8.99
        }
      ]
    }
  ],
  "createdDateTime": "2024-01-01T12:00:00Z",
  "updatedDateTime": "2024-01-02T12:00:00Z",
  "hostIds": "00000000-0000-0000-0000-000000000000",
  "dinnerIds": [
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000"
  ],
  "menuReviewIds": [
    "00000000-0000-0000-0000-000000000000",
    "00000000-0000-0000-0000-000000000000"
  ]
}
```
