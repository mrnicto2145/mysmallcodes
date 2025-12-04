```text
    ```mermaid
        graph TD
            A[Video Input\nfile by mrnicto2145] --> B[Video Decoder]
            B --> C[Processing Pipeline]
            C --> D[Color Correction]
            C --> E[Scaling]
            C --> F[Effects]
            D --> G[Encoder]
            E --> G
            F --> G
            G --> H[Output]

            classDef projectTitle fill:#f9f,stroke:#333,stroke-width:2px;
            class A projectTitle;
            linkStyle default stroke:#555,stroke-width:1px,fill:none;

            style A fill:#e0f7fa,stroke:#00695c,stroke-width:2px
            style B fill:#b2dfdb,stroke:#00695c,stroke-width:2px
            style C fill:#80cbc4,stroke:#00695c,stroke-width:2px
            style D fill:#4db6ac,stroke:#004d40,stroke-width:1.5px
            style E fill:#4db6ac,stroke:#004d40,stroke-width:1.5px
            style F fill:#4db6ac,stroke:#004d40,stroke-width:1.5px
            style G fill:#26a69a,stroke:#004d40,stroke-width:2px
            style H fill:#00897b,stroke:#ffffff,stroke-width:2px,color:#ffffff

            %% Подпись проекта: Обработка видеопотока: Video Input → Video Decoder → Processing Pipeline (Color Correction, Scaling, Effects) → Encoder → Output.
    ```
```