namespace CH04_WeakReferences
{
    using System;
    using System.Threading;

    class Program
    {
        private static readonly LongWeakReferenceObjectManager StrongReferences = new LongWeakReferenceObjectManager();
        private static readonly ShortWeakReferenceObjectManager WeakReferences = new ShortWeakReferenceObjectManager();

        static void Main(string[] _)
        {
            TestLongWeakReference();
            TestStrongReferences();
            TestWeakReferences();
            ProcessReferences();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private static void TestLongWeakReference()
        {
            ReferenceObject strongReference = new ReferenceObject() 
            {
                Id = 1
                , Name = "Reference Object 1"
            };
            WeakReference<ReferenceObject> weakReference = new WeakReference<ReferenceObject>(strongReference);

            weakReference.TryGetTarget(out ReferenceObject referenceObject1);

            Console.WriteLine($"Reference Object 1: {referenceObject1.Name}");

            strongReference = null;
            referenceObject1 = null;

            weakReference.TryGetTarget(out ReferenceObject referenceObject2);

            Console.WriteLine($"Reference Object 2: {referenceObject2.Name}");

            referenceObject2 = null;

            GC.Collect();

            weakReference.TryGetTarget(out ReferenceObject referenceObject3);

            Console.WriteLine($"Reference Object 3a: {referenceObject3.Name}");

            weakReference = null;
            GC.Collect();

            Console.WriteLine($"Reference Object 3b: {referenceObject3.Name}");
        }

        private static void TestStrongReferences()
        {
            var o1 = new ReferenceObject() { Id = 1, Name = "Object 1" };
            var o2 = new ReferenceObject() { Id = 2, Name = "Object 2" };
            var o3 = new ReferenceObject() { Id = 3, Name = "Object 3" };

            StrongReferences.Add(o1);
            StrongReferences.Add(o2);
            StrongReferences.Add(o3);
        }

        private static void TestWeakReferences()
        {
            var o1 = new ReferenceObject() { Id = 1, Name = "Object 4" };
            var o2 = new ReferenceObject() { Id = 2, Name = "Object 5" };
            var o3 = new ReferenceObject() { Id = 3, Name = "Object 6" };

            WeakReferences.Add(o1);
            WeakReferences.Add(o2);
            WeakReferences.Add(o3);

            o1 = null;
            o2 = null;
            o3 = null;
        }

        private static void ProcessReferences()
        {
            int x = 0;

            while(x < 10000)
            {
                StrongReferences.ListObjects();
                WeakReferences.ListObjects();
                Thread.Sleep(2000);
                GC.Collect();
                x++;
            }
        }
    }
}
