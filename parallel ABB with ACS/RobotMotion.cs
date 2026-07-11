using System;
using System.Linq;
using System.Reflection;
using ACS.SPiiPlusNET;

namespace parallel_ABB_with_ACS
{
    internal class RobotMotion
    {
        private Api aCS;

        public RobotMotion(Api aCS)
        {
            this.aCS = aCS;
        }

        // Public helper to move the three axes (angles in degrees).
        // Tries common ACS API methods via reflection and falls back to per-axis calls if needed.
        public void MoveToAngles(double a0, double a1, double a2)
        {
            if (aCS == null)
            {
                System.Diagnostics.Debug.WriteLine("RobotMotion.MoveToAngles: ACS Api is null.");
                return;
            }

            // Build arrays for multi-axis calls
            Axis[] axes = new Axis[] { Axis.ACSC_AXIS_0, Axis.ACSC_AXIS_1, Axis.ACSC_AXIS_2 };
            double[] positions = new double[] { a0, a1, a2 };

            Type apiType = aCS.GetType();

            try
            {
                // 1) Try ToPointM(Axis[] axes, double[] positions, int buffer)
                MethodInfo mToPointM3 = apiType.GetMethod("ToPointM", new Type[] { typeof(Axis[]), typeof(double[]), typeof(int) });
                if (mToPointM3 != null)
                {
                    // use buffer 0 (or choose appropriate buffer)
                    mToPointM3.Invoke(aCS, new object[] { axes, positions, 0 });
                    return;
                }

                // 2) Try ToPointM(Axis[] axes, double[] positions)
                MethodInfo mToPointM2 = apiType.GetMethod("ToPointM", new Type[] { typeof(Axis[]), typeof(double[]) });
                if (mToPointM2 != null)
                {
                    mToPointM2.Invoke(aCS, new object[] { axes, positions });
                    return;
                }

                // 3) Try ToPoint(Axis axis, double position) - call per axis
                MethodInfo mToPointSingle = apiType.GetMethod("ToPoint", new Type[] { typeof(Axis), typeof(double) });
                if (mToPointSingle != null)
                {
                    // Call each axis sequentially (may be blocking depending on API)
                    mToPointSingle.Invoke(aCS, new object[] { axes[0], positions[0] });
                    mToPointSingle.Invoke(aCS, new object[] { axes[1], positions[1] });
                    mToPointSingle.Invoke(aCS, new object[] { axes[2], positions[2] });
                    return;
                }

                // 4) Try Transaction(string) - send a controller-level move command if nothing else exists.
                MethodInfo mTransaction = apiType.GetMethod("Transaction", new Type[] { typeof(string) });
                if (mTransaction != null)
                {
                    // Build a simple transaction string for debugging. Modify this string to match your controller language.
                    string cmd = $"! Move angles: A0={a0:F3} A1={a1:F3} A2={a2:F3}";
                    mTransaction.Invoke(aCS, new object[] { cmd });
                    System.Diagnostics.Debug.WriteLine("RobotMotion.MoveToAngles: Transaction sent (placeholder).");
                    return;
                }

                // If no known API found, log the angles (fallback)
                System.Diagnostics.Debug.WriteLine($"RobotMotion.MoveToAngles: No ACS move API found. Angles = {a0:F3}, {a1:F3}, {a2:F3}");
            }
            catch (TargetInvocationException tie)
            {
                System.Diagnostics.Debug.WriteLine("RobotMotion.MoveToAngles invocation error: " + tie.InnerException?.Message ?? tie.Message);
                throw;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("RobotMotion.MoveToAngles error: " + ex.Message);
                throw;
            }
        }
    }
}