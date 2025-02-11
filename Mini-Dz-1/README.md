<h1 align="center">Мини-ДЗ №1 КПО</h1>

<h2>1. Single Responsibility Principle (SRP)</h2>
<ul>
<li>
  Классы <code>Animal</code> и его наследники (<code>Herbo</code>, <code>Predator</code>, <code>Monkey</code>, <code>Rabbit</code>, <code>Tiger</code>, <code>Wolf</code>) отвечают за представление сущностей животных, их характеристики и поведение
</li>
<li>
  Класс <code>Zoo</code> управляет коллекцией животных и инвентаризационных предметов, а также обеспечивает интеграцию с ветеринарной клиникой
</li>
<li>
  Класс <code>VeterinaryClinic</code> (и интерфейс <code>IVeterinaryClinic</code>) отвечает за проверку здоровья животных
</li>
<li>
  Классы <code>Thing</code>, <code>Table</code> и <code>Computer</code> отвечают за функциональность, связанную с инвентаризацией объектов
</li>
</ul>

<h2>2. Open/Closed Principle (OCP)</h2>
<ul>
  <li>
    Добавление нового типа животного осуществляется посредством создания нового класса, который наследуется от <code>Animal</code> или его производных, при этом не требуется изменять существующий код
  </li>
  <li>
    Дополнительная функциональность (например, новые виды инвентарных объектов) может быть легко добавлена путем расширения базовых классов
  </li>
</ul>

<h2>3. Liskov Substitution Principle (LSP)</h2>
<ul>
  <li>
    Любой объект, созданный на основе класса <code>Animal</code>, может быть использован в методах класса <code>Zoo</code> (таких как <code>AddAnimal</code> или <code>GetTotalFoodConsumption</code>)
  </li>
</ul>

<h2>4. Interface Segregation Principle (ISP)</h2>
<ul>
  <li>
    Интерфейс <code>IAlive</code> предоставляет свойство <code>Food</code> для учета потребляемой еды, в то время как интерфейс <code>IInventory</code> отвечает за инвентарный номер и имя объекта
  </li>
</ul>

<h2>5. Dependency Inversion Principle (DIP)</h2>
<ul>
  <li>
    Класс <code>Zoo</code> зависит от абстракции <code>IVeterinaryClinic</code>, а не от конкретной реализации, что позволяет легко заменить реализацию для тестирования (на <code>FakeVeterinaryClinic</code>).
  </li>
  <li>
    Внедрение зависимостей через конструктор и использование DI-контейнера (<code>Microsoft.Extensions.DependencyInjection</code>)
  </li>
</ul>
