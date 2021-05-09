namespace CH04_PreventingMemoryLeaks
{
    using System;

    class Program
    {
        static void Main(string[] _)
        {
            //RunExcelExamples();
            //UseAnonymousEventSubscriptions();
            WeakReferences();
        }

        private static void RunExcelExamples()
		{
            UsingExcel excel = new UsingExcel();
            excel.RunExcelExamples();
		}

        private static void UseAnonymousEventSubscriptions()
        {
            for (int x = 0; x < 1000000; x++)
            {
                AnonymousEventSubscription aes = new AnonymousEventSubscription();
                aes.Login();
                aes.Logout();
            }
        }

        private static void WeakReferences()
		{
            UsingWeakReferences weakReferences = new UsingWeakReferences();
            weakReferences.RaiseWeakReferenceEvents();
		}
    }
}
