# Task-4-Project-Structure
Проект ASP.NET Core WebAPI реалізований на базі попереднього завдання.
####Має реалізувати ендпоінти які описані в попередньому домашньому завданні. Створити модель для всіх сутностей які описані. Також потрібно добавити якісь seeds дані які будуть по замовчуванню завантажені.

**Серед важливих нюансів:**

* Розділити всю логіку на слої: 
  *Presentation Layer - controller, 
  *Business Layer - service, 
  *Data Access Layer - repository.

* Використати IoC контейнер, тобто розбити всю логіку на різні сервіси та створити для них абстракції 
(все за *IoC і Dependency Inversion Principle*).

* Мати два набори класів: *DTO та Model*. Використати мапінг (можна задіяти бібліотеку AutoMapper).

* Додати валідацію (по бажанню можна використати бібліотеку FluentValidation)

Для роботи з даними реалізувати один з підходів які були описані в лекції, або якщо ви знаєте якийсь інакший, який на вашу думку краще підійде для цього завдання. Проте зберігати їх поки в пам’яті. (Не потрібно реалізовувати операції з реальною базою даних!).
