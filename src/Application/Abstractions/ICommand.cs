namespace Application.Abstractions;

//action that does not return a value
public interface ICommand : IBaseCommand
{
}

//action that does return a value
public interface ICommand<T> : IBaseCommand
{
}

//generic base for injecting any command type
public interface IBaseCommand
{
}