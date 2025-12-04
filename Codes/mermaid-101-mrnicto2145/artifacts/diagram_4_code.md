```text
    ```mermaid
        gantt
            title Проект миграции данных\nAuthor: mrnicto2145
            dateFormat  YYYY-MM-DD
            section Планирование
            Планирование задач               :a1, 2023-10-02, 7d

            section Подготовка
            Подготовка инфраструктуры        :a2, after a1, 14d

            section Миграция
            Миграция тестовых данных        :a3, after a2, 7d
            Валидация                        :a4, after a3, 7d
            Миграция production              :a5, after a4, 2d

            section Завершение
            Мониторинг                       :a6, after a5, 7d

    ```
```