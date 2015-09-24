﻿namespace CovarianceAndContravariance
{
    using ClassHierarchy;

    // LastClass : MiddleClass : BaseClass
    public static class Program
    {
        public static void Main()
        {
            InvariantGeneric();
            ContravariantGeneric();
            CovariantGeneric();
        }

        public static void InvariantGeneric()
        {
            IInvariantGeneric<MiddleClass> genericMiddle = new InvariantGeneric<MiddleClass>();
            genericMiddle.Method(new MiddleClass());

            // This will produce compile-time error:
            // Cannot implicitly convert type 'IInvariantGeneric<MiddleClass>' to 'IInvariantGeneric<BaseClass>'.
            // An explicit conversion exists (are you missing a cast?)
            //// IInvariantGeneric<BaseClass> genericBase = genericMiddle;

            // This will produce compile-time error:
            // Cannot implicitly convert type 'IInvariantGeneric<MiddleClass>' to 'IInvariantGeneric<LastClass>'.
            // An explicit conversion exists (are you missing a cast?)
            //// IInvariantGeneric<LastClass> genericLast = genericMiddle;
        }

        public static void ContravariantGeneric()
        {
            IContravariantGeneric<MiddleClass> genericMiddle = new ContravariantGeneric<MiddleClass>();
            genericMiddle.Method(new MiddleClass());

            // This will produce compile-time error:
            // Cannot implicitly convert type 'IContravariantGeneric<MiddleClass>' to 'IContravariantGeneric<BaseClass>'.
            // An explicit conversion exists (are you missing a cast?)
            //// IContravariantGeneric<BaseClass> genericBase = genericMiddle;

            // This is OK:
            IContravariantGeneric<LastClass> genericLast = genericMiddle;
        }

        public static void CovariantGeneric()
        {
            ICovariantGeneric<MiddleClass> genericMiddle = new CovariantGeneric<MiddleClass>();

            // This is OK:
            ICovariantGeneric<BaseClass> genericBase = genericMiddle;

            // This will produce compile-time error:
            // Cannot implicitly convert type 'ICovariantGeneric<MiddleClass>' to 'ICovariantGeneric<LastClass>'.
            // An explicit conversion exists (are you missing a cast?)
            //// ICovariantGeneric<LastClass> genericLast = genericMiddle;
        }
    }
}
