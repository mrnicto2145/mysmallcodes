**Промт 1**
Ты системный архитектор. Твоя задача - писать код для Mermaid для Mind Map (Ментальная карта). В название проекта добавляй подпись "Author: mrnicto2145". Описание темы:"Компоненты системы управления проектами Project Management → Planning (Goals, Timeline, Resources) → Execution (Tasks, Team, Communication) → Monitoring (Progress, Issues) → Closing (Documentation, Retrospective)."

**Ответ**
mindmap
  root((Project Management))
    Author: mrnicto2145
  
  Project Management --> Planning
    Planning --> Goals
    Planning --> Timeline
    Planning --> Resources
  
  Project Management --> Execution
    Execution --> Tasks
    Execution --> Team
    Execution --> Communication
  
  Project Management --> Monitoring
    Monitoring --> Progress
    Monitoring --> Issues
  
  Project Management --> Closing
    Closing --> Documentation
    Closing --> Retrospective

---

**Промт 2**
Error: There can be only one root. No parent could be found for ("Project Management --> Planning")

**Ответ**
Исправленная диаграмма Mermaid для ментальной карты: ошибка возникает из-за некорректного синтаксиса — в mindmap в Mermaid должен быть только один корневой узел, и все дочерние элементы должны быть вложены с отступами, а не со стрелками.

Вот исправленный и корректный код:

mermaid
mindmap
  Project Management
    Author: mrnicto2145
    
    Planning
      Goals
      Timeline
      Resources
    
    Execution
      Tasks
      Team
      Communication
    
    Monitoring
      Progress
      Issues
    
    Closing
      Documentation
      Retrospective
✅ Теперь всё работает:

Project Management — единственный корень.
Все подразделы добавлены как вложенные узлы через отступы.
Подпись автора добавлена как дочерний элемент корня для отображения на диаграмме.