using CH12_ResponsiveMAUI.Data;

namespace CH12_ResponsiveMAUI;

public partial class AppShell : Shell
{
    private BaseEntity _baseEntity;
    public AppShell()
	{
		InitializeComponent();
    }

    public AppShell(BaseEntity baseEntity)
    {
        InitializeComponent();
        _baseEntity = baseEntity;
    }
}
