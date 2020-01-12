using System.Threading.Tasks;
/// <summary>
/// Вызов трудоемкой функции ассинхронно
/// </summary>
public class AsyncJob
{
    /// <summary>Вызывается после вызова функции</summary>
    public System.Action OnEndJob;
    /// <summary>Трудоемкая функция</summary>
    private System.Action _action;

    /// <summary>
    /// Добавить трудоемкую функцию
    /// </summary>
    /// <param name="action">Трудоемкая функция</param>
    public AsyncJob(System.Action action)
    {
        _action = action;
    }

    /// <summary>
    /// Начать выполнение функции
    /// </summary>
    public void Start()
    {
        DoWorkAsync();
    }

    /// <summary>
    /// Вызов ассинхронно функции
    /// </summary>
    /// <returns></returns>
    async Task DoWorkAsync()
    {
        await Task.Run(_action);
        OnEndJob?.Invoke();
    }
}
