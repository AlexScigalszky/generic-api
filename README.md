# generic-api

A generic API for whatever entity you have

This project have a POST endpoint ( `/Entity` ) that return entities from database de generic way, without custom models, servicies or that kind of stuff.

Your just need declare a Entity in Context (CodeFirst with EntityFramework) and that's all. 

## An Example
```
{
  "entity": "Log",
  "take": 100,
  "skip": 0,
  "orderBy": "Id",
  "orderByDescending": null,
  "criterias": []
}
```


## There are a few endpoint to help to undestand the situacion:
- `/Errors`
Return the posible errors 
- `/Operators`
Return the operators avaliables to make a criteria
- `/Properties`
Return a list of properties of an entity. This es helpful to make criterias or short the restults
