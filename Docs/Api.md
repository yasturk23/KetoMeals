# Keto Meals API

- [Keto Meals API](#buber-Meal-api)
  - [Create Meal](#create-Meal)
    - [Create Meal Request](#create-Meal-request)
    - [Create Meal Response](#create-Meal-response)
  - [Get Meal](#get-Meal)
    - [Get Meal Request](#get-Meal-request)
    - [Get Meal Response](#get-Meal-response)
  - [Update Meal](#update-Meal)
    - [Update Meal Request](#update-Meal-request)
    - [Update Meal Response](#update-Meal-response)
  - [Delete Meal](#delete-Meal)
    - [Delete Meal Request](#delete-Meal-request)
    - [Delete Meal Response](#delete-Meal-response)

## Create Meal

### Create Meal Request

```js
POST / Meals;
```

```json
{
  "name": "Keto Egg Noodles",
  "description": "This keto pasta noodles recipe has just 2.7g net carbs and 3 ingredients!",
  "ingredients": [
    "2 cups Mozzarella Cheese",
    "4 large Egg Yolks",
    "1/2cup Lupin Flour"
  ],
  "calories": "248.7",
  "net_carbs": "2.7"
}
```

### Create Meal Response

```js
201 Created
```

```yml
Location: {{host}}/Meals/{{id}}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Keto Egg Noodles",
  "description": "This keto pasta noodles recipe has just 2.7g net carbs and 3 ingredients!",
  "ingredients": [
    "2 cups Mozzarella Cheese",
    "4 large Egg Yolks",
    "1/2cup Lupin Flour"
  ],
  "calories": "248.7",
  "net_carbs": "2.7"
}
```

## Get Meal

### Get Meal Request

```js
GET /Meals/{{id}}
```

### Get Meal Response

```js
200 Ok
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Keto Egg Noodles",
  "description": "This keto pasta noodles recipe has just 2.7g net carbs and 3 ingredients!",
  "ingredients": [
    "2 cups Mozzarella Cheese",
    "4 large Egg Yolks",
    "1/2cup Lupin Flour"
  ],
  "calories": "248.7",
  "net_carbs": "2.7"
}
```

## Update Meal

### Update Meal Request

```js
PUT /Meals/{{id}}
```

```json
{
  "name": "Keto Egg Noodles",
  "description": "This keto pasta noodles recipe has just 2.7g net carbs and 3 ingredients!",
  "ingredients": [
    "2 cups Mozzarella Cheese",
    "4 large Egg Yolks",
    "1/2cup Lupin Flour"
  ],
  "calories": "248.7",
  "net_carbs": "2.7"
}
```

### Update Meal Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Meals/{{id}}
```

## Delete Meal

### Delete Meal Request

```js
DELETE /Meals/{{id}}
```

### Delete Meal Response

```js
204 No Content
```
