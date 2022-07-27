namespace CH04_WeakReferences
{
    using System;
    using System.Collections.Generic;
    
    internal class ShortWeakReferenceObjectManager
    {
        private readonly List<WeakReference<ReferenceObject>> Objects = new List<WeakReference<ReferenceObject>>();
        
        public void Add(ReferenceObject o)
        {
            Objects.Add(new WeakReference<ReferenceObject>(o));
        }

        public void ListObjects()
        {
            Console.WriteLine("Short Weak Reference Objects: ");
            foreach (var reference in Objects)
            {
                reference.TryGetTarget(out ReferenceObject referenceObject);
                if (referenceObject != null)
                    Console.WriteLine($"- {referenceObject.Name}");
            }
        }
    }
}
