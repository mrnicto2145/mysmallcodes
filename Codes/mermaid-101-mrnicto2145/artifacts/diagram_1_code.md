```text
    ```mermaid
        graph TD
            A[main<br><sub>Author: mrnicto2145</sub>] --> B[feature/user-auth]
            A --> C[feature/dashboard]
            
            B --> D[Commits в feature/user-auth]
            D --> E[Pull Request]
            E --> F[Merge в main]
            
            C --> G[Commits в feature/dashboard]
            G --> H[Pull Request]
            H --> I[Merge в main]

            style A fill:#00a8e8,stroke:#333
            style B fill:#f09a9d,stroke:#333
            style C fill:#f09a9d,stroke:#333
            style F fill:#28a745,stroke:#333,color:#fff
            style I fill:#28a745,stroke:#333,color:#fff
    ```
```