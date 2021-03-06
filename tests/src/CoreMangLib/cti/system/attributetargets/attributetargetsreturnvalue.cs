using System;
/// <summary>
///ReturnValue
/// </summary>

public class AttributeTargetsReturnValue
{
    public static int Main()
    {
        AttributeTargetsReturnValue AttributeTargetsReturnValue = new AttributeTargetsReturnValue();

        TestLibrary.TestFramework.BeginTestCase("AttributeTargetsReturnValue");
        if (AttributeTargetsReturnValue.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
       TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
      
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Verify the AttributeTargets.ReturnValue value is 0x2000. ");
        try
        {
            int expectValue = 0x2000;
            if ((int)AttributeTargets.ReturnValue != expectValue)
            {
                TestLibrary.TestFramework.LogError("001.1", " AttributeTargets.ReturnValue should return 0x2000.");
                retVal = false;
            }
           
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }
       
        return retVal;
    }
   
}

