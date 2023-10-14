using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfast = new();

    public ErrorOr<Created> CreateBreakfast(Breakfast breakfast)
    {
        _breakfast.Add(breakfast.Id, breakfast);
        return Result.Created;
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_breakfast.TryGetValue(id, out var breakfast))
        {
            return breakfast;
        }

        return Errors.Breakfast.NotFound;
    }

    public ErrorOr<UpsertedBreakfast> UpdateBreakfast(Breakfast breakfast)
    {
        bool isNewlyCreated = !_breakfast.ContainsKey(breakfast.Id);
        _breakfast[breakfast.Id] = breakfast;

        return new UpsertedBreakfast(isNewlyCreated);
    }

    public ErrorOr<Deleted> DeleteBreakfast(Guid id)
    {
        _breakfast.Remove(id);
        return Result.Deleted;
    }

}