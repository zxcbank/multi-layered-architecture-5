namespace Models.Users;

public record User
{
    public long UserId { get; private set; }

    public long Pin { get; private set; }

    public UserRole Role { get; }

    public decimal MoneyAmount { get; set; }

    public User(long userId, long pin, UserRole role)
    {
        UserId = userId;
        Pin = pin;
        MoneyAmount = 0;
        Role = role;
    }

    public User(long userId, long pin, UserRole role, decimal moneyamount)
    {
        UserId = userId;
        Pin = pin;
        MoneyAmount = moneyamount;
        Role = role;
    }
}