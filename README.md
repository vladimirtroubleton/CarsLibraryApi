# Описание методов :
Методы получения списка машин:
HttpGet - https://localhost:44358/api/Cars/GetCars (без какого либо тела)
HtppPost - https://localhost:44358/api/Cars/GetCars (body json)
Пример исходящего json:
{
"attrKey":"TypeCar",
"attrValues":"Седан"
}
Доступные атрибуты для поиска :
Number:string - номер машины
TypeCar:string - тип машины
Model:string - модель машины
ReleaseYear:int - год выпуска машины
OwnerName:string - имя владельца
CountHourseForces:string - количество лошадиных сил
Создание машины:
httpPost - https://localhost:44358/api/Cars/CreateCar;
Исходящий json:
{"numberCar":"XA1T3",
"typeCar": "Седан",
"modelCar": "Nissan Almera N16 ",
"releaseYear":"2003",
"ownerName":"Владимир Дегтерев",
"countHourseForces": "86"
}
Получение статистики:
HttpGet - https://localhost:44358/api/Cars/GetCarsStat 
Получение логов:
HttpGet https://localhost:44358/api/Log/GetLogs
