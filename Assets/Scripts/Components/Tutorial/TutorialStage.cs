namespace Client
{
    struct Tutorial
    {

    }

    public enum TutorialStage
    {
        //LVL 1 :
        LVL1_Buy_Car = 0, //
        LVL1_Click_OK = 1, //
        LVL1_Click_Play = 2, //
        LVL1_Click_Play_Done = 3,
        LVL1_Click_Next = 4, //
        //LVL 2 :
        LVL2_Buy_Car_1 = 5, //
        LVL2_Merge_1 = 6,
        LVL2_Click_OK_1 = 7, //
        LVL2_Buy_Car_2 = 8,
        LVL2_Click_Play_1 = 9, //
        LVL2_Click_Play_Done_1 = 10,
        //Playing LVL 2 for a while...
        LVL2_Buy_Car_3 = 11, //
        LVL2_Merge_2 = 12,
        LVL2_Merge_2_Done = 13,
        //////LVL2_Click_Play_2       = 13,
        //////LVL2_Click_Play_Done_2  = 14,
        //LVL 3-4 :
        Frozen_Start = 14,
        Frozen_End = 15,
        //LVL 5:
        Drag_Mine_Start = 16,
        Drag_Mine_End = 17,
        Drag_Barricades_Start = 18,
        Drag_Barricades_End = 19,
        //Tutorial End
        End = 20
    }
}
