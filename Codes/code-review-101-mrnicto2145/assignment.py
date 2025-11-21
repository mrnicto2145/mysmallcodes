"""
Assignment 3: Diabetes Dataset Analysis - TEMPLATE
Goal: Diabetes data analysis - regression task

TASKS:
1. Load data in load_data()
2. Compute target variable statistics in target_analysis()
3. Compute feature statistics in feature_statistics()
4. Create histogram and KDE plot of target in visualize_target()
5. Create histograms of all features in visualize_features()
6. Create scatter plots of features vs target in scatter_features_vs_target()
7. Compute and visualize correlations in correlation_analysis()
"""


import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.datasets import load_diabetes

# Set font to support Unicode (e.g. for labels)
plt.rcParams['font.sans-serif'] = ['DejaVu Sans']
plt.rcParams['axes.unicode_minus'] = False


def load_data():
    """Load the Diabetes dataset and convert to DataFrame"""
    data = load_diabetes()
    df = pd.DataFrame(data.data, columns=data.feature_names)
    df['target'] = data.target  # add target variable
    return df


def target_analysis(df):
    """Analyze the target variable (disease progression)"""
    target = df['target']
    print("\n" + "-" * 40)
    print("АНАЛИЗ ЦЕЛЕВОЙ ПЕРЕМЕННОЙ (target)")
    print("-" * 40)
    print(f"Среднее: {target.mean():.2f}")
    print(f"Медиана: {target.median():.2f}")
    print(f"Стандартное отклонение: {target.std():.2f}")
    print(f"Минимум: {target.min():.2f}")
    print(f"Максимум: {target.max():.2f}")
    print(f"Размах: {target.max() - target.min():.2f}")
    print(f"25% квантиль: {target.quantile(0.25):.2f}")
    print(f"50% квантиль (медиана): {target.quantile(0.50):.2f}")
    print(f"75% квантиль: {target.quantile(0.75):.2f}")


def feature_statistics(df):
    """Compute statistics for features s1-s6"""
    feature_cols = ['s1', 's2', 's3', 's4', 's5', 's6']
    features = df[feature_cols]
    print("\n" + "-" * 40)
    print("СТАТИСТИКА ПО ПРИЗНАКАМ (s1-s6)")
    print("-" * 40)
    stats = features.describe().loc[['mean', 'std', 'min', 'max']].T
    print(stats.round(2))


def visualize_target(df):
    """Visualize the distribution of the target variable"""
    plt.figure(figsize=(12, 5))

    # Histogram
    plt.subplot(1, 2, 1)
    df['target'].hist(bins=30, color='skyblue', edgecolor='black')
    plt.axvline(df['target'].mean(), color='red', linestyle='--', label=f'Среднее = {df["target"].mean():.2f}')
    plt.title('Гистограмма целевой переменной (target)')
    plt.xlabel('Значение')
    plt.ylabel('Частота')
    plt.legend()

    # KDE plot
    plt.subplot(1, 2, 2)
    sns.kdeplot(df['target'], color='green', fill=True)
    plt.axvline(df['target'].mean(), color='red', linestyle='--', label=f'Среднее = {df["target"].mean():.2f}')
    plt.title('KDE график распределения (target)')
    plt.xlabel('Значение')
    plt.ylabel('Плотность')
    plt.legend()

    plt.tight_layout()
    plt.savefig('03_diabetes_target_distribution.png', dpi=300, bbox_inches='tight')
    plt.show()


def visualize_features(df):
    """Visualize the distribution of features s1-s6"""
    feature_cols = ['s1', 's2', 's3', 's4', 's5', 's6']
    features = df[feature_cols]

    fig, axes = plt.subplots(3, 2, figsize=(12, 10))
    axes = axes.ravel()

    for i, col in enumerate(features.columns):
        axes[i].hist(features[col], bins=25, color='lightcoral', edgecolor='black')
        axes[i].set_title(f'Гистограмма: {col}')
        axes[i].set_xlabel('Значение')
        axes[i].set_ylabel('Частота')

    plt.tight_layout()
    plt.savefig('03_diabetes_features_distribution.png', dpi=300, bbox_inches='tight')
    plt.show()


def scatter_features_vs_target(df):
    """Scatter plots of features s1-s6 vs target variable"""
    feature_cols = ['s1', 's2', 's3', 's4', 's5', 's6']

    fig, axes = plt.subplots(3, 2, figsize=(12, 10))
    axes = axes.ravel()

    for i, col in enumerate(feature_cols):
        axes[i].scatter(df[col], df['target'], alpha=0.6, color='teal')
        axes[i].set_title(f'{col} vs target')
        axes[i].set_xlabel(col)
        axes[i].set_ylabel('Target (progression)')

    plt.tight_layout()
    plt.savefig('03_diabetes_features_vs_target.png', dpi=300, bbox_inches='tight')
    plt.show()


def correlation_analysis(df):
    """Analyze correlations of s1-s6 features with target variable"""
    feature_cols = ['s1', 's2', 's3', 's4', 's5', 's6']
    correlations = {}

    for col in feature_cols:
        corr = df[col].corr(df['target'])
        correlations[col] = corr

    corr_series = pd.Series(correlations).sort_values()
    print("\n" + "-" * 40)
    print("КОРРЕЛЯЦИИ ПРИЗНАКОВ S1-S6 С ЦЕЛЕВОЙ ПЕРЕМЕННОЙ")
    print("-" * 40)
    print(corr_series.round(4))

    # Visualization
    plt.figure(figsize=(8, 5))
    corr_series.plot(kind='barh', color='slateblue', edgecolor='black')
    plt.title('Корреляция s1-s6 с целевой переменной')
    plt.xlabel('Коэффициент корреляции')
    plt.grid(axis='x', linestyle='--', alpha=0.7)
    plt.tight_layout()
    plt.savefig('03_diabetes_correlation_bars.png', dpi=300, bbox_inches='tight')
    plt.show()


def main():
    """Main function"""
    print("=" * 60)
    print("ЗАДАНИЕ 3: EXPLORATORY DATA ANALYSIS - DIABETES DATASET")
    print("=" * 60)

    df = load_data()
    print(f"\nДатасет загружен. Размер: {df.shape}")
    print("\nПервые 5 строк:")
    print(df.head())

    target_analysis(df)
    feature_statistics(df)
    visualize_target(df)
    visualize_features(df)
    scatter_features_vs_target(df)
    correlation_analysis(df)

    print("\n" + "=" * 60)
    print("Анализ завершен!")
    print("=" * 60)


if __name__ == "__main__":
    main()
