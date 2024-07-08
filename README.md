# TestTaskSGS

##Task
На основе ежедневных данных о курсах валют ЦБ (https://www.cbr-xml-daily.ru/daily_json.js) необходимо создать Web-сервис с использованием ASP.Net Core, который реализует 2 API метода:
GET /currencies — должен возвращать список курсов валют с возможностью пагинации
GET /currency/ — должен возвращать курс валюты для переданного идентификатора валюты
Можно использовать любые NuGet-пакеты.
Конкретная реализация получения, хранения и возврата данных, а также их формат могут быть выбраны на усмотрение разработчика.


На реализацию потрачено около 4-5 часов

[Ветка с использованием MemoryCache](https://github.com/Issatonk/TestTaskSGS/tree/MemoryCache)

## Screnshots

### Start page /currencies/{page}?pagesise=
![currencies](https://github.com/Issatonk/Issatonk/blob/main/src/TestTaskSGS/1.png)

### pagination
![pagination](https://github.com/Issatonk/Issatonk/blob/main/src/TestTaskSGS/2.png)

### Search By Id /currency/
![pagination](https://github.com/Issatonk/Issatonk/blob/main/src/TestTaskSGS/3.png)
![pagination](https://github.com/Issatonk/Issatonk/blob/main/src/TestTaskSGS/4.png)

### Search By CharCode /currency/
![pagination](https://github.com/Issatonk/Issatonk/blob/main/src/TestTaskSGS/5.png)

### Currency conversion
![pagination](https://github.com/Issatonk/Issatonk/blob/main/src/TestTaskSGS/6.png)
