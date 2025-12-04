# Mermaid — Примеры и кейсы для рисования диаграмм

## 1. Flowchart (Блок-схема)

### Кейс 1.1: Алгоритм проверки пароля
Нарисовать блок-схему валидации пароля с проверкой на длину (≥8), наличие заглавной буквы, цифры и спецсимволов. На выходе — валидный/невалидный пароль.

### Кейс 1.2: Процесс регистрации пользователя
Отобразить жизненный цикл: заполнение формы → проверка email → верификация → создание аккаунта → отправка приветственного письма. С условиями для ошибок на каждом этапе.

### Кейс 1.3: Логика сортировки в интернет-магазине
Пользователь выбирает категорию → фильтр по цене → сортировка (по популярности/отзывам/цене) → отображение результатов. Опция добавления в корзину.

### Кейс 1.4: Распределение задач CI/CD конвейеру
Код → lint → тесты → build → deploy в staging → manual approval → deploy в production. С условиями для отката при ошибках.

### Кейс 1.5: Древо решений для выбора структуры данных
Нужна быстрая вставка? → Нужен поиск? → Нужна сортировка? На основе ответов рекомендовать: Array, LinkedList, HashTable, Tree, Heap.

---

## 2. Sequence Diagram (Диаграмма взаимодействия)

### Кейс 2.1: Аутентификация в системе с OAuth
Клиент → Приложение → OAuth сервер. Запрос кода → Получение токена → Проверка токена → Возврат данных пользователя.

### Кейс 2.2: Микросервисная архитектура при заказе в интернет-магазине
Клиент → API Gateway → Order Service → Payment Service → Inventory Service → Notification Service. С обработкой успеха и ошибок.

### Кейс 2.3: WebSocket соединение для чата в реальном времени
Клиент 1 → Server (соединение) → Клиент 2. Сообщение от Клиента 1 → Server → Broadcast → Клиент 2 (получение).

### Кейс 2.4: REST API запрос с retry логикой
Клиент → API (первый запрос) → ошибка 500 → retry (второй запрос) → успех → response.

### Кейс 2.5: Синхронизация данных между фронтенд и бэкенд
Frontend (React) → Backend API → Database. Создание записи → Backend проверка → сохранение → возврат ID → Frontend обновляет состояние.

---

## 3. Class Diagram (Диаграмма классов)

### Кейс 3.1: Иерархия животных
Класс Animal с методами (eat, sleep, move) → наследование: Mammal, Bird, Fish → далее Dog, Cat, Eagle, Shark с переопределением методов.

### Кейс 3.2: Система управления персоналом
Класс Person → наследование: Employee, Manager, Director. Атрибуты: name, salary, department. Методы: getSalary(), getBonus(). Связи: Manager имеет список Employees.

### Кейс 3.3: E-commerce система (Товары и Заказы)
Классы: Product (id, name, price), Order (id, date, total), Customer (id, email), Cart (items: List<Product>). Ассоциации и композиции между ними.

### Кейс 3.4: Система уведомлений
Интерфейс Notifier (send()) → реализация: EmailNotifier, SMSNotifier, PushNotifier. Класс NotificationService использует Notifier.

### Кейс 3.5: Система обработки платежей
Абстрактный класс PaymentMethod → Реализация: CreditCardPayment, PayPalPayment, CryptocurrencyPayment. Класс PaymentProcessor агрегирует PaymentMethod.

---

## 4. State Diagram (Диаграмма состояний)

### Кейс 4.1: Жизненный цикл заказа в интернет-магазине
Pending → Processing → Shipped → Delivered → Completed. С возможностью перехода к Cancelled из Pending и Processing.

### Кейс 4.2: Состояния медиаплеера
Stopped → Playing → Paused → Playing. События: play(), pause(), stop(), resume().

### Кейс 4.3: Вход пользователя в приложение
LoggedOut → EnteringCredentials → AuthenticatingUser → LoggedIn. Условие на ошибку аутентификации → возврат в LoggedOut.

### Кейс 4.4: Процесс публикации статьи в блоге
Draft → Review → Approved → Published → Archived. С откатом из Review обратно в Draft при необходимости.

### Кейс 4.5: Состояния видеоконференции
Idle → Connecting → Connected → Recording → Connected → Disconnecting → Idle. События для каждого перехода.

---

## 5. Entity Relationship Diagram (ER диаграмма)

### Кейс 5.1: Система управления университетом
Сущности: Student, Course, Professor, Department, Grade. Отношения: Student зарегистрирован на Course, Professor преподает Course, Course принадлежит Department.

### Кейс 5.2: Система больницы
Сущности: Patient, Doctor, Appointment, Prescription, Medicine. Отношения: Patient посещает Doctor на Appointment, Doctor выписывает Prescription, Prescription содержит Medicine.

### Кейс 5.3: Социальная сеть
Сущности: User, Post, Comment, Like, Message. Отношения: User создает Post, User делает Comment на Post, User лайкает Post, User отправляет Message другому User.

### Кейс 5.4: Система библиотеки
Сущности: Book, Author, Member, Loan, Genre. Отношения: Book написан Author, Book принадлежит Genre, Member берет Loan книги, Loan связан с Book.

### Кейс 5.5: E-commerce платформа
Сущности: Customer, Product, Order, OrderItem, Category, Warehouse. Отношения: Customer делает Order, Order содержит OrderItems, OrderItem ссылается на Product, Product принадлежит Category, Product находится на Warehouse.

---

## 6. Gantt Chart (Диаграмма Ганта)

### Кейс 6.1: Разработка веб-приложения
Этапы: Дизайн (2 недели) → Фронтенд разработка (3 недели, после дизайна) → Бэкенд разработка (4 недели, параллельно с фронтенд) → Тестирование (2 недели, после обоих) → Развертывание (1 неделя).

### Кейс 6.2: Планирование курса по программированию
Модуль 1 (2 недели) → Модуль 2 (2 недели) → Модуль 3 (3 недели) → Финальный проект (4 недели, может перекрываться с модулем 3) → Экзамен (1 день).

### Кейс 6.3: Создание продукта (от идеи к выпуску)
Исследование рынка (3 недели) → Разработка концепции (2 недели) → Прототип (4 недели) → Тестирование (2 недели) → Маркетинг (2 недели) → Запуск (1 день).

### Кейс 6.4: Проект миграции данных
Планирование (1 неделя) → Подготовка инфраструктуры (2 недели) → Миграция тестовых данных (1 неделя) → Валидация (1 неделя) → Миграция production (2 дня) → Мониторинг (1 неделя).

### Кейс 6.5: Семестровый план факультета
Семинар 1 (1 месяц) → Контрольная 1 (1 день) → Семинар 2 (1 месяц) → Контрольная 2 (1 день) → Финальная подготовка (2 недели) → Экзаменационная сессия (1 неделя).

---

## 7. Mind Map (Ментальная карта)

### Кейс 7.1: Структура курса по машинному обучению
Основной узел: Machine Learning → Supervised Learning (Classification, Regression) → Unsupervised Learning (Clustering, Dimensionality Reduction) → Reinforcement Learning (Q-Learning, Policy Gradient) → Deployment (Model Optimization, Monitoring).

### Кейс 7.2: Структура стека Web-разработчика
Frontend & Backend → Frontend (HTML/CSS, JavaScript, Frameworks: React/Vue/Angular) → Backend (Python/Node.js, Databases, APIs) → DevOps (Docker, CI/CD, Cloud).

### Кейс 7.3: Компоненты системы управления проектами
Project Management → Planning (Goals, Timeline, Resources) → Execution (Tasks, Team, Communication) → Monitoring (Progress, Issues) → Closing (Documentation, Retrospective).

### Кейс 7.4: Иерархия компьютерных наук
Computer Science → Programming (Languages, Paradigms) → Algorithms & Data Structures → Databases → Software Engineering → AI & Machine Learning.

### Кейс 7.5: Подготовка к собеседованию на вакансию
Interview Preparation → Technical Skills (Algorithms, System Design, Coding) → Soft Skills (Communication, Problem Solving) → Interview Practice (Mock Interviews) → Reflection & Improvement.

---

## 8. Pie Chart (Круговая диаграмма)

### Кейс 8.1: Распределение времени на разработку функции
Backend: 40%, Frontend: 35%, Testing: 15%, Documentation: 10%.

### Кейс 8.2: Использование памяти в приложении
Database Cache: 45%, Application State: 30%, Media Files: 20%, Logs: 5%.

### Кейс 8.3: Причины ошибок в production
Logic Errors: 50%, Configuration Issues: 20%, Infrastructure: 15%, Third-party Dependencies: 15%.

### Кейс 8.4: Распределение бюджета ИТ проекта
Development: 50%, Infrastructure & Hosting: 20%, Testing & QA: 15%, Support & Maintenance: 15%.

### Кейс 8.5: Популярность языков программирования в компании
Python: 35%, JavaScript: 30%, Java: 20%, Go: 10%, Other: 5%.

---

## 9. Git Graph (Диаграмма Git)

### Кейс 9.1: Feature branch workflow
main → feature/user-auth ветка → commits → pull request → merge в main. Параллельно другой feature branch feature/dashboard.

### Кейс 9.2: Git flow для production release
develop → release/1.0.0 ветка → bugfixes → merge в main (с тегом 1.0.0) и back-merge в develop.

### Кейс 9.3: Hotfix процесс для критической ошибки
main (production) → hotfix/security-patch → commits → merge в main и develop.

### Кейс 9.4: Сложное ветвление с multiple features
main → feature1 → feature1a, feature1b (параллельные подветки) → merge обратно → merge в main.

### Кейс 9.5: Реbase и merge стратегия
feature branch → rebase на latest main → linear history → merge в main (fast-forward).

---

## 10. C4 Diagram (Архитектура системы)

### Кейс 10.1: Context диаграмма e-commerce системы
System: E-Commerce Platform в центре → User (посещает сайт) → Payment Provider (обрабатывает платежи) → Email Service (отправляет письма) → Warehouse System (управляет инвентарем).

### Кейс 10.2: Container диаграмма микросервисной архитектуры
API Gateway → Order Service, Payment Service, Inventory Service (все контейнеры) → Database, Message Queue (общие ресурсы).

### Кейс 10.3: Component диаграмма внутри User Service
User Service содержит: Authentication Component, Profile Manager, Settings Manager → все общаются с User Database.

### Кейс 10.4: Code диаграмма для функции авторизации
Classes: LoginController → AuthenticationService → UserRepository → Database. Взаимодействие через методы.

### Кейс 10.5: Многоуровневая архитектура веб-приложения
Context: Web App ↔ Backend API ↔ Database → Container: Web Browser (фронтенд) ↔ API Server (бэкенд) ↔ PostgreSQL.

---

## 11. Block Diagram (Блок-диаграмма)

### Кейс 11.1: Архитектура IoT системы
Input Devices (датчики) → Edge Gateway → Cloud Service → Database → Analytics → Dashboard (UI).

### Кейс 11.2: Обработка видеопотока
Video Input → Video Decoder → Processing Pipeline (Color Correction, Scaling, Effects) → Encoder → Output.

### Кейс 11.3: Система управления энергией в доме
Solar Panels → Charge Controller → Battery Storage → Inverter → Home Electrical Panel → Devices.

### Кейс 11.4: ML Pipeline для прогнозирования
Data Collection → Data Preprocessing → Feature Engineering → Model Training → Model Evaluation → Deployment.

### Кейс 11.5: Логическая архитектура мобильного приложения
UI Layer (Activities, Fragments) → Business Logic Layer (ViewModels, Services) → Data Layer (Repositories, Database, API) → External Services.

---

## 12. Requirement Diagram (Диаграмма требований)

### Кейс 12.1: Требования для системы управления проектами
REQ001: Users Management → REQ002: Project Creation (derives) → REQ003: Task Assignment (refines) → REQ004: Reporting (traces).

### Кейс 12.2: Требования для мобильного приложения
REQ001: Offline Functionality → REQ002: Data Sync (satisfies) → REQ003: Push Notifications (refines).

### Кейс 12.3: Требования безопасности для финтех приложения
REQ001: Authentication (contains: REQ002: 2FA, REQ003: OAuth) → REQ004: Encryption (verifies).

### Кейс 12.4: Требования для веб-фреймворка
REQ001: Performance (traces: REQ002: Page Load Time < 2s) → REQ003: SEO Optimization (derives).

### Кейс 12.5: Требования для API
REQ001: Rate Limiting → REQ002: API Documentation → REQ003: Error Handling (refines REQ001).

---

## 13. Sankey Diagram (Диаграмма потоков)

### Кейс 13.1: Воронка продаж
Visitors (1000) → Sign-Ups (300) → Paid Users (100) → Retained Users (60) → Loyal Customers (30).

### Кейс 13.2: Энергетические потоки в доме
Electricity Supply (10000 units) → Lighting (3000) → Heating (4000) → Appliances (2000) → Waste (1000).

### Кейс 13.3: Обработка пользовательских запросов в поддержке
Support Tickets (500) → Resolved by AI (200) → Escalated to Human (300) → Resolved (250) → Closed (450).

### Кейс 13.4: Распределение бюджета в стартапе
Total Budget (1M) → Development (500K) → Marketing (250K) → Operations (150K) → Reserve (100K).

### Кейс 13.5: Миграция пользователей между версиями приложения
v1 Users (10000) → Migrated to v2 (8000) → Upgraded to Premium (2000) → Churned (2000).

---

## 14. Timeline (Временная шкала)

### Кейс 14.1: История развития интернета
1960-1970: ARPANET → 1980-1990: World Wide Web → 1990-2000: Dot-com era → 2000-2010: Social Media → 2010-2025: Mobile & AI.

### Кейс 14.2: Эволюция Python
2000: Python 1.5 → 2008: Python 3.0 → 2010: Python 2.7 → 2020: Python 3.8 → 2025: Python 3.13.

### Кейс 14.3: Жизненный цикл проекта разработки ПО
2024-Q1: Планирование → 2024-Q2: Разработка → 2024-Q3: Тестирование → 2024-Q4: Развертывание → 2025: Поддержка.

### Кейс 14.4: История технологических прорывов в ML
2012: AlexNet → 2017: Transformer → 2018: BERT → 2020: GPT-3 → 2023: LLMs Boom → 2024: Multimodal Models.

### Кейс 14.5: Запуск стартапа по месяцам
Месяц 1: Идея & Планирование → Месяц 2-3: MVP разработка → Месяц 4: Beta запуск → Месяц 5-6: Улучшения → Месяц 7: Public Launch.

