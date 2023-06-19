using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using UnityEngine;


namespace Assets.Scripts.WorksequenceClasses
{
    public class WorksequenceListLoadManager
    {
        public WorksequenceList workSequenceList { get; private set; }

        public WorksequenceListLoadManager() { InitializeList(); }

        public WorkSequence GetWorkSequence(string name) { return workSequenceList.GetWorkSequence(name); }
        public void InitializeList()
        {
            workSequenceList = new WorksequenceList();

            // Initialize Worksequence 0_00 - start
            WorkSequence workSequence0_00 = new WorkSequence("workSequence0_00");
            workSequence0_00.SetStartingWorksequence();
            workSequence0_00.SetAllowedToUse("HandDisinfectant");
            workSequence0_00.SetWorkplateActive(false);
            workSequenceList.Add(workSequence0_00);

           
            // Initialize Worksequence 1_00 - disinfect hands
            WorkSequence workSequence1_00 = new WorkSequence("workSequence1_00");
            workSequence1_00.Substitute(workSequence0_00);
            workSequence1_00.iconList.HandsDisinfected();
            workSequence1_00.SetAllowedToUse("Gloves");
            workSequenceList.Add(workSequence1_00);

            
            // Initialize Worksequence 2_00 - put on gloves
            WorkSequence workSequence2_00 = new WorkSequence("workSequence2_00");
            workSequence2_00.Substitute(workSequence1_00);
            workSequence2_00.iconList.Gloves();
            workSequence2_00.SetAllowedToUse("Bed");
            workSequenceList.Add(workSequence2_00);


            // Initialize Worksequence 3_00 - set bed on working height
            WorkSequence workSequence3_00 = new WorkSequence("workSequence3_00");
            workSequence3_00.Substitute(workSequence2_00);
            workSequence3_00.bedIsUp = true;
            workSequence3_00.SetAllowedToUse("");
            workSequenceList.Add(workSequence3_00);

            // Initialize Worksequence 3_01 - set bed on working height
            WorkSequence workSequence3_01 = new WorkSequence("workSequence3_01");
            workSequence3_01.Substitute(workSequence3_00);
            workSequence3_01.SetAllowedToUse("PlaneDisinfectant");
            workSequenceList.Add(workSequence3_01);


            // Initialize Worksequence 4_00 - disinfect area of firstaidcabinet: take tissue
            WorkSequence workSequence4_00 = new WorkSequence("workSequence4_00");
            workSequence4_00.Substitute(workSequence3_01);
            workSequence4_00.GetModel("DressingOnArmDown_Model").SetActive(false);
            workSequence4_00.GetModel("DressingOnArmUp_Model").SetActive(true);
            workSequence4_00.lidIsUp = true;
            workSequence4_00.GetModel("Tissue_Model").SetActive(true);
            workSequence4_00.SetItemAtHand("Tissue");
            workSequence4_00.GetHitplane("Hitplane_Workplate_Big").SetActive(true);
            workSequence4_00.SetAllowedToUse("Hitplane_Workplate_Big");
            workSequenceList.Add(workSequence4_00);
            
            // Initialize Worksequence 4_01 - put objects on small workplate
            WorkSequence workSequence4_01 = new WorkSequence("workSequence4_01");
            workSequence4_01.Substitute(workSequence4_00);
            workSequence4_01.SetItemAtHand("Tissue");
            workSequence4_01.PlaceObject("Gloves", "ObjectPlace_Gloves_cleaning");
            workSequence4_01.PlaceObject("HandDisinfectant", "ObjectPlace_HandDisinfectant_cleaning");
            workSequence4_01.SetAllowedToUse("Hitplane_Workplate_Big");
            workSequenceList.Add(workSequence4_01);

            // Initialize Worksequence 4_02 - clean big workplate
            WorkSequence workSequence4_02 = new WorkSequence("workSequence4_02");
            workSequence4_02.Substitute(workSequence4_01);
            workSequence4_02.SetItemAtHand("Tissue");
            workSequence4_02.SetAllowedToUse("Hitplane_Workplate_Big");
            workSequenceList.Add(workSequence4_02);

            // Initialize Worksequence 4_03 - put objects on big workplate
            WorkSequence workSequence4_03 = new WorkSequence("workSequence4_03");
            workSequence4_03.Substitute(workSequence4_02);
            workSequence4_03.SetItemAtHand("Tissue");
            workSequence4_03.PlaceObject("Gloves", "ObjectPlace_Gloves");
            workSequence4_03.PlaceObject("HandDisinfectant", "ObjectPlace_HandDisinfectant");
            workSequence4_03.PlaceObject("PlaneDisinfectant", "ObjectPlace_PlaneDisinfectant_cleaning");
            workSequence4_03.PlaceObject("Apron", "ObjectPlace_Apron_cleaning");
            workSequence4_03.GetHitplane("Hitplane_Workplate_Big").SetActive(false);
            workSequence4_03.GetHitplane("Hitplane_Workplate_Small").SetActive(true);
            workSequence4_03.SetAllowedToUse("Hitplane_Workplate_Small");
            workSequenceList.Add(workSequence4_03);

            // Initialize Worksequence 4_04 - clean small workplate
            WorkSequence workSequence4_04 = new WorkSequence("workSequence4_04");
            workSequence4_04.Substitute(workSequence4_03);
            workSequence4_04.SetItemAtHand("Tissue");
            workSequence4_04.SetAllowedToUse("Hitplane_Workplate_Small");
            workSequenceList.Add(workSequence4_04);

            // Initialize Worksequence 104_05 - put objects on standard positions
            WorkSequence workSequence104_05 = new WorkSequence("workSequence104_05");
            workSequence104_05.Substitute(workSequence4_04);
            workSequence104_05.GetHitplane("Hitplane_Workplate_Small").SetActive(false);
            workSequence104_05.SetItemAtHand("Tissue");
            workSequence104_05.PlaceObject("PlaneDisinfectant", "ObjectPlace_PlaneDisinfectant");
            workSequence104_05.PlaceObject("Apron", "ObjectPlace_Apron");
            workSequence104_05.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence104_05);


            // Initialize Worksequence 5_00 - throw away plane disinfectant tissue
            WorkSequence workSequence5_00 = new WorkSequence("workSequence5_00");
            workSequence5_00.Substitute(workSequence104_05);
            workSequence5_00.GetModel("Tissue_Model").SetActive(false);
            workSequence5_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence5_00);


            // Initialize Worksequence 6_00 - throw away gloves
            WorkSequence workSequence6_00 = new WorkSequence("workSequence6_00");
            workSequence6_00.Substitute(workSequence5_00);
            workSequence6_00.iconList.Hands();
            workSequence6_00.SetAllowedToUse("HandDisinfectant");
            workSequenceList.Add(workSequence6_00);

            
            // Initialize Worksequence 7_00 - disinfect hands
            WorkSequence workSequence7_00 = new WorkSequence("workSequence7_00");
            workSequence7_00.Substitute(workSequence6_00);
            workSequence7_00.iconList.HandsDisinfected();
            workSequence7_00.SetAllowedToUse("Apron");
            workSequenceList.Add(workSequence7_00);


            // Initialize Worksequence 8_00 - put on apron
            WorkSequence workSequence8_00 = new WorkSequence("workSequence8_00");
            workSequence8_00.Substitute(workSequence7_00);
            workSequence8_00.GetUsableObject("Apron").SetActive(false);
            workSequence8_00.iconList.Apron();
            workSequence8_00.SetWorkplateActive(true);
            workSequence8_00.SetAllowedToUse("Safebox");
            workSequenceList.Add(workSequence8_00);

            // ------------------
            // Put items on plate
            //-------------------

            // Initialize Worksequence 9_00 - take Safebox
            WorkSequence workSequence9_00 = new WorkSequence("workSequence9_00");
            workSequence9_00.Substitute(workSequence8_00);
            workSequence9_00.GetUsableObject("Safebox").SetColliderActive(false);
            workSequence9_00.SetItemAtHand("Safebox");
            workSequence9_00.SetAllowedToUse("Hitplane_Safebox");
            workSequenceList.Add(workSequence9_00);

            // Initialize Worksequence 9_01 - put Safebox on workplate
            WorkSequence workSequence9_01 = new WorkSequence("workSequence9_01");
            workSequence9_01.Substitute(workSequence9_00);
            workSequence9_01.PlaceObject("Safebox", "ObjectPlace_Safebox");
            workSequence9_01.GetUsableObject("Safebox").SetColliderActive(true);
            workSequence9_01.SetItemAtHand("");
            workSequence9_01.SetAllowedToUse("Fixation");
            workSequenceList.Add(workSequence9_01);

            // Initialize Worksequence 9_02 - take Fixation
            WorkSequence workSequence9_02 = new WorkSequence("workSequence9_02");
            workSequence9_02.Substitute(workSequence9_01);
            workSequence9_02.GetUsableObject("Fixation").SetColliderActive(false);
            workSequence9_02.SetItemAtHand("Fixation");
            workSequence9_02.SetAllowedToUse("Hitplane_Fixation");
            workSequenceList.Add(workSequence9_02);
            
            // Initialize Worksequence 9_03 - put Fixation on workplate
            WorkSequence workSequence9_03 = new WorkSequence("workSequence9_03");
            workSequence9_03.Substitute(workSequence9_02);
            workSequence9_03.PlaceObject("Fixation", "ObjectPlace_Fixation");
            workSequence9_03.GetUsableObject("Fixation").SetColliderActive(true);
            workSequence9_03.SetItemAtHand("");
            workSequence9_03.SetAllowedToUse("WoundDisinfectant");
            workSequenceList.Add(workSequence9_03);

            // Initialize Worksequence 9_04 - take WoundDisinfectant
            WorkSequence workSequence9_04 = new WorkSequence("workSequence9_04");
            workSequence9_04.Substitute(workSequence9_03);
            workSequence9_04.GetUsableObject("WoundDisinfectant").SetColliderActive(false);
            workSequence9_04.SetItemAtHand("WoundDisinfectant");
            workSequence9_04.SetAllowedToUse("Hitplane_WoundDisinfectant");
            workSequenceList.Add(workSequence9_04);

            // Initialize Worksequence 9_05 - put WoundDisinfectant on workplate
            WorkSequence workSequence9_05 = new WorkSequence("workSequence9_05");
            workSequence9_05.Substitute(workSequence9_04);
            workSequence9_05.PlaceObject("WoundDisinfectant", "ObjectPlace_WoundDisinfectant");
            workSequence9_05.GetUsableObject("WoundDisinfectant").SetColliderActive(true);
            workSequence9_05.SetItemAtHand("");
            workSequence9_05.SetAllowedToUse("Mask");
            workSequenceList.Add(workSequence9_05);

            // Initialize Worksequence 9_06 - take Mask
            WorkSequence workSequence9_06 = new WorkSequence("workSequence9_06");
            workSequence9_06.Substitute(workSequence9_05);
            workSequence9_06.GetUsableObject("Mask").SetColliderActive(false);
            workSequence9_06.SetItemAtHand("Mask");
            workSequence9_06.SetAllowedToUse("Hitplane_Mask");
            workSequenceList.Add(workSequence9_06);

            // Initialize Worksequence 9_07 - put Mask on workplate
            WorkSequence workSequence9_07 = new WorkSequence("workSequence9_07");
            workSequence9_07.Substitute(workSequence9_06);
            workSequence9_07.PlaceObject("Mask", "ObjectPlace_Mask");
            workSequence9_07.GetUsableObject("Mask").SetColliderActive(true);
            workSequence9_07.SetItemAtHand("");
            workSequence9_07.SetAllowedToUse("Compress");
            workSequenceList.Add(workSequence9_07);

            // Initialize Worksequence 9_08 - take Compress
            WorkSequence workSequence9_08 = new WorkSequence("workSequence9_08");
            workSequence9_08.Substitute(workSequence9_07);
            workSequence9_08.GetUsableObject("Compress").SetColliderActive(false);
            workSequence9_08.SetItemAtHand("Compress");
            workSequence9_08.SetAllowedToUse("Hitplane_Compress");
            workSequenceList.Add(workSequence9_08);

            // Initialize Worksequence 9_09 - put Compress on workplate
            WorkSequence workSequence9_09 = new WorkSequence("workSequence9_09");
            workSequence9_09.Substitute(workSequence9_08);
            workSequence9_09.PlaceObject("Compress", "ObjectPlace_Compress");
            workSequence9_09.GetUsableObject("Compress").SetColliderActive(true);
            workSequence9_09.SetItemAtHand("");
            workSequence9_09.SetAllowedToUse("Swab");
            workSequenceList.Add(workSequence9_09);

            // Initialize Worksequence 9_10 - take swab
            WorkSequence workSequence9_10 = new WorkSequence("workSequence9_10");
            workSequence9_10.Substitute(workSequence9_09);
            workSequence9_10.GetUsableObject("Swab").SetColliderActive(false);
            workSequence9_10.SetItemAtHand("Swab");
            workSequence9_10.SetAllowedToUse("Hitplane_Swab");
            workSequenceList.Add(workSequence9_10);

            // Initialize Worksequence 9_11 - put swab on workplate
            WorkSequence workSequence9_11 = new WorkSequence("workSequence9_11");
            workSequence9_11.Substitute(workSequence9_10);
            workSequence9_11.PlaceObject("Swab", "ObjectPlace_Swab");
            workSequence9_11.GetUsableObject("Swab").SetColliderActive(true);
            workSequence9_11.SetItemAtHand("");
            workSequence9_11.SetAllowedToUse("Tweezer");
            workSequenceList.Add(workSequence9_11);

            // Initialize Worksequence 9_12 - take Tweezer
            WorkSequence workSequence9_12 = new WorkSequence("workSequence9_12");
            workSequence9_12.Substitute(workSequence9_11);
            workSequence9_12.GetUsableObject("Tweezer").SetColliderActive(false);
            workSequence9_12.SetItemAtHand("Tweezer");
            workSequence9_12.SetAllowedToUse("Hitplane_Tweezer");
            workSequenceList.Add(workSequence9_12);

            // Initialize Worksequence 9_13 - put Tweezer on workplate
            WorkSequence workSequence9_13 = new WorkSequence("workSequence9_13");
            workSequence9_13.Substitute(workSequence9_12);
            workSequence9_13.PlaceObject("Tweezer", "ObjectPlace_Tweezer");
            workSequence9_13.GetUsableObject("Tweezer").SetColliderActive(true);
            workSequence9_13.SetItemAtHand("");
            workSequence9_13.SetAllowedToUse("Scissors");
            workSequenceList.Add(workSequence9_13);

            // Initialize Worksequence 9_14 - take scissors
            WorkSequence workSequence9_14 = new WorkSequence("workSequence9_14");
            workSequence9_14.Substitute(workSequence9_13);
            workSequence9_14.GetUsableObject("Scissors").SetColliderActive(false);
            workSequence9_14.SetItemAtHand("Scissors");
            workSequence9_14.SetAllowedToUse("Hitplane_Scissors");
            workSequenceList.Add(workSequence9_14);

            // Initialize Worksequence 9_15 - put scissors on workplate
            WorkSequence workSequence9_15 = new WorkSequence("workSequence9_15");
            workSequence9_15.Substitute(workSequence9_14);
            workSequence9_15.PlaceObject("Scissors", "ObjectPlace_Scissors");
            workSequence9_15.GetUsableObject("Scissors").SetColliderActive(true);
            workSequence9_15.SetItemAtHand("");
            workSequence9_15.SetAllowedToUse("Dish");
            workSequenceList.Add(workSequence9_15);

            // Initialize Worksequence 9_16 - take dish
            WorkSequence workSequence9_16 = new WorkSequence("workSequence9_16");
            workSequence9_16.Substitute(workSequence9_15);
            workSequence9_16.GetUsableObject("Dish").SetColliderActive(false);
            workSequence9_16.SetItemAtHand("Dish");
            workSequence9_16.SetAllowedToUse("Hitplane_Dish");
            workSequenceList.Add(workSequence9_16);

            // Initialize Worksequence 9_17 - put dish on workplate
            WorkSequence workSequence9_17 = new WorkSequence("workSequence9_17");
            workSequence9_17.Substitute(workSequence9_16);
            workSequence9_17.PlaceObject("Dish", "ObjectPlace_Dish");
            workSequence9_17.GetUsableObject("Dish").SetColliderActive(true);
            workSequence9_17.SetItemAtHand("");
            workSequence9_17.SetAllowedToUse("Cellulose");
            workSequenceList.Add(workSequence9_17);

            // Initialize Worksequence 9_18 - take cellulose
            WorkSequence workSequence9_18 = new WorkSequence("workSequence9_18");
            workSequence9_18.Substitute(workSequence9_17);
            workSequence9_18.GetUsableObject("Cellulose").SetColliderActive(false);
            workSequence9_18.SetItemAtHand("Cellulose");
            workSequence9_18.SetAllowedToUse("Hitplane_Cellulose");
            workSequenceList.Add(workSequence9_18);

            // Initialize Worksequence 9_19 - put cellulose on workplate
            WorkSequence workSequence9_19 = new WorkSequence("workSequence9_19");
            workSequence9_19.Substitute(workSequence9_18);
            workSequence9_19.GetModel("Cellulose_Model").SetActive(false);
            workSequence9_19.GetModel("CelluloseOnDish_Model").SetActive(true);
            workSequence9_19.SetItemAtHand("");
            workSequence9_19.SetAllowedToUse("Hitplane_Dish");
            workSequenceList.Add(workSequence9_19);

            //-----------------
            // Prepare material
            //-----------------


            // Initialize Worksequence 10_00 - open material with peel-off-technic: Compress
            WorkSequence workSequence10_00 = new WorkSequence("workSequence10_00");
            workSequence10_00.Substitute(workSequence9_19);
            workSequence10_00.SetWorkplateActive(false);
            workSequence10_00.SetAllowedToUse("Compress");
            workSequenceList.Add(workSequence10_00);

            // Initialize Worksequence 10_01 - open material with peel-off-technic: Swab
            WorkSequence workSequence10_01 = new WorkSequence("workSequence10_01");
            workSequence10_01.Substitute(workSequence10_00);
            workSequence10_01.SetAnimationPlayed("openingCompress", true);
            workSequence10_01.SetAllowedToUse("Swab");
            workSequenceList.Add(workSequence10_01);

            // Initialize Worksequence 10_02 - open material with peel-off-technic: Tweezer
            WorkSequence workSequence10_02 = new WorkSequence("workSequence10_02");
            workSequence10_02.Substitute(workSequence10_01);
            workSequence10_02.SetAnimationPlayed("openingSwab", true);
            workSequence10_02.SetAllowedToUse("Tweezer");
            workSequenceList.Add(workSequence10_02);


            // Initialize Worksequence 11_00 - take Scissors
            WorkSequence workSequence11_00 = new WorkSequence("workSequence11_00");
            workSequence11_00.Substitute(workSequence10_02);
            workSequence11_00.SetAnimationPlayed("openingTweezer", true);
            workSequence11_00.SetAllowedToUse("Scissors");
            workSequenceList.Add(workSequence11_00);

            // Initialize Worksequence 11_01 - cut fixation
            WorkSequence workSequence11_01 = new WorkSequence("workSequence11_01");
            workSequence11_01.Substitute(workSequence10_02);
            workSequence11_01.SetItemAtHand("Scissors");
            workSequence11_01.GetUsableObject("Scissors").SetColliderActive(false);
            workSequence11_01.SetAllowedToUse("Fixation");
            workSequenceList.Add(workSequence11_01);

            // Initialize Worksequence 11_02 - throw away scissors
            WorkSequence workSequence11_02 = new WorkSequence("workSequence11_02");
            workSequence11_02.Substitute(workSequence11_01);
            workSequence11_02.SetItemAtHand("Scissors");
            workSequence11_02.GetModel("FixationTape_Model").SetActive(true);
            workSequence11_02.SetAllowedToUse("Safebox");
            workSequenceList.Add(workSequence11_02);


            // Initialize Worksequence 12_00 - take WoundDisinfectant
            WorkSequence workSequence12_00 = new WorkSequence("workSequence12_00");
            workSequence12_00.Substitute(workSequence11_02);
            workSequence12_00.GetUsableObject("Scissors").SetActive(false);
            workSequence12_00.SetAllowedToUse("WoundDisinfectant");
            workSequenceList.Add(workSequence12_00);

            // Initialize Worksequence 12_01 - saturate swabs
            WorkSequence workSequence12_01 = new WorkSequence("workSequence12_01");
            workSequence12_01.Substitute(workSequence12_00);
            workSequence12_01.GetUsableObject("WoundDisinfectant").SetColliderActive(false);
            workSequence12_01.SetItemAtHand("WoundDisinfectant");
            workSequence12_01.SetAllowedToUse("Swab");
            workSequenceList.Add(workSequence12_01);

            // Initialize Worksequence 12_02 - put WoundDisinfectant back
            WorkSequence workSequence12_02 = new WorkSequence("workSequence12_02");
            workSequence12_02.Substitute(workSequence12_01);
            workSequence12_02.SetItemAtHand("WoundDisinfectant");
            workSequence12_02.GetHitplane("Hitplane_WoundDisinfectant").SetActive(true);
            workSequence12_02.SetAllowedToUse("Hitplane_WoundDisinfectant");
            workSequenceList.Add(workSequence12_02);


            // Initialize Worksequence 13_00 - take cellulose and dish
            WorkSequence workSequence13_00 = new WorkSequence("workSequence13_00");
            workSequence13_00.Substitute(workSequence12_02);
            workSequence13_00.SetItemAtHand("");
            workSequence13_00.PlaceObject("WoundDisinfectant", "ObjectPlace_WoundDisinfectant");
            workSequence13_00.GetUsableObject("WoundDisinfectant").SetColliderActive(true);
            workSequence13_00.GetHitplane("Hitplane_WoundDisinfectant").SetActive(false);
            workSequence13_00.SetAllowedToUse("Dish");
            workSequenceList.Add(workSequence13_00);


            // Initialize Worksequence 13_01 - put cellulose and dish on bed
            WorkSequence workSequence13_01 = new WorkSequence("workSequence13_01");
            workSequence13_01.Substitute(workSequence13_00);
            workSequence13_01.SetItemAtHand("Dish");
            workSequence13_01.GetUsableObject("Dish").SetColliderActive(false);
            workSequence13_01.GetHitplane("Hitplane_DishOnBed").SetActive(true);
            workSequence13_01.SetAllowedToUse("Hitplane_DishOnBed");
            workSequenceList.Add(workSequence13_01);

            // Initialize Worksequence 14_00 - put cellulose and dish on bed
            WorkSequence workSequence14_00 = new WorkSequence("workSequence14_00");
            workSequence14_00.Substitute(workSequence13_01);
            workSequence14_00.iconList.Hands();
            workSequence14_00.PlaceObject("Dish", "ObjectPlace_DishOnBed");
            workSequence14_00.GetHitplane("Hitplane_DishOnBed").SetActive(false);
            workSequence14_00.SetAllowedToUse("HandDisinfectant");
            workSequenceList.Add(workSequence14_00);

            //----------------------------
            // Preperation of the patient 
            //----------------------------

            // Initialize Worksequence 15_0 - disinfect hands
            WorkSequence workSequence15_00 = new WorkSequence("workSequence15_00");
            workSequence15_00.Substitute(workSequence14_00);
            workSequence15_00.iconList.HandsDisinfected();
            workSequence15_00.SetAllowedToUse("Gloves");
            workSequenceList.Add(workSequence15_00);


            // Initialize Worksequence 16_00 - put on gloves
            WorkSequence workSequence16_00 = new WorkSequence("workSequence16_00");
            workSequence16_00.Substitute(workSequence15_00);
            workSequence16_00.iconList.Gloves();
            workSequence16_00.GetHitplane("Hitplane_CelluloseOnBed").SetActive(true);
            workSequence16_00.SetAllowedToUse("Hitplane_CelluloseOnBed");
            workSequenceList.Add(workSequence16_00);


            // Initialize Worksequence 17_00 - put cellulose under arm
            WorkSequence workSequence17_00 = new WorkSequence("workSequence17_00");
            workSequence17_00.Substitute(workSequence16_00);
            workSequence17_00.GetHitplane("Hitplane_CelluloseOnBed").SetActive(false);
            workSequence17_00.GetModel("CelluloseOnDish_Model").SetActive(false);
            workSequence17_00.GetModel("CelluloseUnderArm_Model").SetActive(true);
            workSequence17_00.SetAllowedToUse("OldDressing");
            workSequenceList.Add(workSequence17_00);

            // Initialize Worksequence 17_01 - take old dressing
            WorkSequence workSequence17_01 = new WorkSequence("workSequence17_01");
            workSequence17_01.Substitute(workSequence17_00);
            workSequence17_01.GetModel("DressingOnArmUp_Model").SetActive(false);
            workSequence17_01.GetModel("OldDressing_Model").SetActive(true);
            workSequence17_01.GetUsableObject("OldDressing").SetColliderActive(false);
            workSequence17_01.SetItemAtHand("OldDressing");
            workSequence17_01.GetUsableObject("Dish").SetColliderActive(true);
            workSequence17_01.SetAllowedToUse("Dish");
            workSequenceList.Add(workSequence17_01);

            // Initialize Worksequence 18_00 - put olf dressing in dish
            WorkSequence workSequence18_00 = new WorkSequence("workSequence18_00");
            workSequence18_00.Substitute(workSequence17_01);
            workSequence18_00.GetModel("OldDressing_Model").SetActive(false);
            workSequence18_00.GetModel("OldDressingInDish_Model").SetActive(true);
            workSequence18_00.SetItemAtHand("");
            workSequence18_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence18_00);


            // Initialize Worksequence 19_00 - throw away gloves
            WorkSequence workSequence19_00 = new WorkSequence("workSequence19_00");
            workSequence19_00.Substitute(workSequence18_00);
            workSequence19_00.iconList.Hands();
            workSequence19_00.SetAllowedToUse("HandDisinfectant");
            workSequenceList.Add(workSequence19_00);


            //---------------
            // Woundtreatment 
            //---------------


            // Initialize Worksequence 20_00 - disinfect hands
            WorkSequence workSequence20_00 = new WorkSequence("workSequence20_00");
            workSequence20_00.Substitute(workSequence19_00);
            workSequence20_00.iconList.HandsDisinfected();
            workSequence20_00.GetHitplane("Hitplane_Arm").SetActive(true);
            workSequence20_00.SetAllowedToUse("Hitplane_Arm");
            workSequenceList.Add(workSequence20_00);


            // Initialize Worksequence 21_00 - evaluate wound
            WorkSequence workSequence21_00 = new WorkSequence("workSequence21_00");
            workSequence21_00.Substitute(workSequence20_00);
            workSequence21_00.SetAllowedToUse("Gloves");
            workSequenceList.Add(workSequence21_00);

            // Initialize Worksequence 22_00 - put on gloves
            WorkSequence workSequence22_00 = new WorkSequence("workSequence22_00");
            workSequence22_00.Substitute(workSequence21_00);
            workSequence22_00.iconList.Gloves();
            workSequence22_00.SetAllowedToUse("Tweezer"); 
            workSequenceList.Add(workSequence22_00);

            // Initialize Worksequence 23_00 - take tweezer
            WorkSequence workSequence23_00 = new WorkSequence("workSequence23_00");
            workSequence23_00.Substitute(workSequence22_00);
            workSequence23_00.GetModel("Tweezer_Model").SetActive(false);
            workSequence23_00.GetModel("TweezerAtHand_Model").SetActive(true);
            workSequence23_00.GetUsableObject("TweezerAtHand").SetColliderActive(false);
            workSequence23_00.SetItemAtHand("TweezerAtHand");
            workSequence23_00.SetAllowedToUse("Swab");
            workSequenceList.Add(workSequence23_00);

            // Initialize Worksequence 23_01 - take swab1
            WorkSequence workSequence23_01 = new WorkSequence("workSequence23_01");
            workSequence23_01.Substitute(workSequence23_00);
            workSequence23_01.GetModel("Swab1").SetActive(false);
            workSequence23_01.GetModel("SwabOnTweezer_Model").SetActive(true);
            workSequence23_01.SetItemAtHand("TweezerAtHand");
            workSequence23_01.SetAllowedToUse("Hitplane_Arm");
            workSequenceList.Add(workSequence23_01);

            // Initialize Worksequence 23_02 - clean wound
            WorkSequence workSequence23_02 = new WorkSequence("workSequence23_02");
            workSequence23_02.Substitute(workSequence23_01);
            workSequence23_02.GetModel("TweezerAtHand_Model").SetActive(false);
            workSequence23_02.GetModel("SwabOnTweezer_Model").SetActive(false);
            workSequence23_02.GetModel("TweezerAtWound_Model").SetActive(true);
            workSequence23_02.GetModel("SwabOnTweezerAtWound_Model").SetActive(true);
            workSequence23_02.SetAllowedToUse("");
            workSequenceList.Add(workSequence23_02);

            // Initialize Worksequence 23_03 - clean wound
            WorkSequence workSequence23_03 = new WorkSequence("workSequence23_03");
            workSequence23_03.Substitute(workSequence23_02);
            workSequence23_03.GetModel("TweezerAtWound_Model").SetActive(false);
            workSequence23_03.GetModel("SwabOnTweezerAtWound_Model").SetActive(false);
            workSequence23_03.GetModel("TweezerAtHand_Model").SetActive(true);
            workSequence23_03.GetModel("SwabOnTweezer_Model").SetActive(true);
            workSequence23_03.SetItemAtHand("TweezerAtHand");
            workSequence23_03.SetAllowedToUse("Dish");
            workSequenceList.Add(workSequence23_03);

            // Initialize Worksequence 23_04 - put swab1 in dish
            WorkSequence workSequence23_04 = new WorkSequence("workSequence23_04");
            workSequence23_04.Substitute(workSequence23_03);
            workSequence23_04.GetModel("SwabOnTweezer_Model").SetActive(false);
            workSequence23_04.GetModel("SwabInDish1_Model").SetActive(true);
            workSequence23_04.SetItemAtHand("TweezerAtHand");
            workSequence23_04.SetAllowedToUse("Swab");
            workSequenceList.Add(workSequence23_04);

            // Initialize Worksequence 23_05 - take swab2
            WorkSequence workSequence23_05 = new WorkSequence("workSequence23_05");
            workSequence23_05.Substitute(workSequence23_04);
            workSequence23_05.GetModel("Swab2").SetActive(false);
            workSequence23_05.GetModel("SwabOnTweezer_Model").SetActive(true);
            workSequence23_05.SetItemAtHand("TweezerAtHand");
            workSequence23_05.SetAllowedToUse("Hitplane_Arm");
            workSequenceList.Add(workSequence23_05);

            // Initialize Worksequence 23_06 - clean wound
            WorkSequence workSequence23_06 = new WorkSequence("workSequence23_06");
            workSequence23_06.Substitute(workSequence23_05);
            workSequence23_06.GetModel("TweezerAtHand_Model").SetActive(false);
            workSequence23_06.GetModel("SwabOnTweezer_Model").SetActive(false);
            workSequence23_06.GetModel("TweezerAtWound_Model").SetActive(true);
            workSequence23_06.GetModel("SwabOnTweezerAtWound_Model").SetActive(true);
            workSequence23_06.SetAllowedToUse("");
            workSequenceList.Add(workSequence23_06);

            // Initialize Worksequence 23_07 - clean wound
            WorkSequence workSequence23_07 = new WorkSequence("workSequence23_07");
            workSequence23_07.Substitute(workSequence23_06);
            workSequence23_07.GetModel("TweezerAtWound_Model").SetActive(false);
            workSequence23_07.GetModel("SwabOnTweezerAtWound_Model").SetActive(false);
            workSequence23_07.GetModel("TweezerAtHand_Model").SetActive(true);
            workSequence23_07.GetModel("SwabOnTweezer_Model").SetActive(true);
            workSequence23_07.SetItemAtHand("TweezerAtHand");
            workSequence23_07.SetAllowedToUse("Dish");
            workSequenceList.Add(workSequence23_07);

            // Initialize Worksequence 24_00 - put swab2 in dish
            WorkSequence workSequence24_00 = new WorkSequence("workSequence24_00");
            workSequence24_00.Substitute(workSequence23_07);
            workSequence24_00.GetModel("SwabOnTweezer_Model").SetActive(false);
            workSequence24_00.GetModel("SwabInDish2_Model").SetActive(true);
            workSequence24_00.SetItemAtHand("TweezerAtHand");
            workSequence24_00.SetAllowedToUse("Safebox");
            workSequenceList.Add(workSequence24_00);


            // Initialize Worksequence 25_00 - put tweezer in safebox
            WorkSequence workSequence25_00 = new WorkSequence("workSequence25_00");
            workSequence25_00.Substitute(workSequence24_00);
            workSequence25_00.GetUsableObject("TweezerAtHand").SetActive(false);
            workSequence25_00.SetItemAtHand("");
            workSequence25_00.SetAllowedToUse("Compress");
            workSequenceList.Add(workSequence25_00);


            // Initialize Worksequence 25_01 - take compress
            WorkSequence workSequence25_01 = new WorkSequence("workSequence25_01");
            workSequence25_01.Substitute(workSequence25_00);
            workSequence25_01.GetModel("Compress_Model").SetActive(false);
            workSequence25_01.GetModel("CompressAtHand_Model").SetActive(true);
            workSequence25_01.SetItemAtHand("CompressAtHand");
            workSequence25_01.SetAllowedToUse("Hitplane_Arm");
            workSequenceList.Add(workSequence25_01);
                      
            // Initialize Worksequence 26_00 - put compress on wound
            WorkSequence workSequence26_00 = new WorkSequence("workSequence26_00");
            workSequence26_00.Substitute(workSequence25_01);
            workSequence26_00.GetUsableObject("CompressAtHand").SetActive(false);
            workSequence26_00.GetModel("CompressOnArm_Model").SetActive(true);
            workSequence26_00.SetItemAtHand("");
            workSequence26_00.SetAllowedToUse("FixationTape");
            workSequenceList.Add(workSequence26_00);


            // Initialize Worksequence 26_01 - take fixationtape
            WorkSequence workSequence26_01 = new WorkSequence("workSequence26_01");
            workSequence26_01.Substitute(workSequence26_00);
            workSequence26_01.GetUsableObject("FixationTape").SetColliderActive(false);
            workSequence26_01.SetItemAtHand("FixationTape");
            workSequence26_01.SetAllowedToUse("Hitplane_Arm");
            workSequenceList.Add(workSequence26_01);

            //--------
            // Cleanup
            //--------

            // Initialize Worksequence 27_00 - put fixationtape on wound
            WorkSequence workSequence27_00 = new WorkSequence("workSequence27_00");
            workSequence27_00.Substitute(workSequence26_01);
            workSequence27_00.GetModel("DressingOnArmUp_Model").SetActive(true);
            workSequence27_00.GetUsableObject("FixationTape").SetActive(false);
            workSequence27_00.SetItemAtHand("");
            workSequence27_00.SetAllowedToUse("Dish");
            workSequenceList.Add(workSequence27_00);

            // Initialize Worksequence 27_01 - take dish
            WorkSequence workSequence27_01 = new WorkSequence("workSequence27_01");
            workSequence27_01.Substitute(workSequence27_00);
            workSequence27_01.SetItemAtHand("Dish");
            workSequence27_01.GetUsableObject("Dish").SetColliderActive(false);
            workSequence27_01.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence27_01);

            // Initialize Worksequence 27_02 - throw away dish
            WorkSequence workSequence27_02 = new WorkSequence("workSequence27_02");
            workSequence27_02.Substitute(workSequence27_01);
            workSequence27_02.GetUsableObject("Dish").SetActive(false);
            workSequence27_02.GetModel("DishInRubbish_Model").SetActive(true);
            workSequence27_02.GetModel("SwabInRubbish_Model").SetActive(true);
            workSequence27_02.GetModel("OldDressingInDishInRubbish_Model").SetActive(true);
            workSequence27_02.GetHitplane("Hitplane_CelluloseOnBed").SetActive(true);
            workSequence27_02.SetItemAtHand("");
            workSequence27_02.SetAllowedToUse("Hitplane_CelluloseOnBed");
            workSequenceList.Add(workSequence27_02);


            // Initialize Worksequence 27_03 - take cellulose
            WorkSequence workSequence27_03 = new WorkSequence("workSequence27_03");
            workSequence27_03.Substitute(workSequence27_02);
            workSequence27_03.GetHitplane("Hitplane_CelluloseOnBed").SetActive(false);
            workSequence27_03.GetModel("CelluloseUnderArm_Model").SetActive(false);
            workSequence27_03.GetModel("Cellulose_Model").SetActive(true);
            workSequence27_03.SetItemAtHand("Cellulose");
            workSequence27_03.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence27_03);

            // Initialize Worksequence 28_00 - throw away cellulose
            WorkSequence workSequence28_00 = new WorkSequence("workSequence28_00");
            workSequence28_00.Substitute(workSequence27_03);
            workSequence28_00.GetUsableObject("Cellulose").SetActive(false);
            workSequence28_00.GetModel("CelluloseInRubbish_Model").SetActive(true);
            workSequence28_00.SetItemAtHand("");
            workSequence28_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence28_00);


            // Initialize Worksequence 29_00 - throw away gloves
            WorkSequence workSequence29_00 = new WorkSequence("workSequence29_00");
            workSequence29_00.Substitute(workSequence28_00);
            workSequence29_00.iconList.Hands();
            workSequence29_00.SetAllowedToUse("HandDisinfectant");
            workSequenceList.Add(workSequence29_00);

            // Initialize Worksequence 30_00 - disinfect hands
            WorkSequence workSequence30_00 = new WorkSequence("workSequence30_00");
            workSequence30_00.Substitute(workSequence29_00);
            workSequence30_00.iconList.HandsDisinfected();
            workSequence30_00.SetAllowedToUse("Gloves");
            workSequenceList.Add(workSequence30_00);

            // Initialize Worksequence 31_00 - put on gloves
            WorkSequence workSequence31_00 = new WorkSequence("workSequence31_00");
            workSequence31_00.Substitute(workSequence30_00);
            workSequence31_00.iconList.Gloves();
            workSequence31_00.SetAllowedToUse("Bed");
            workSequenceList.Add(workSequence31_00);

            // Initialize Worksequence 31_01 - put on gloves
            WorkSequence workSequence31_01 = new WorkSequence("workSequence31_01");
            workSequence31_01.Substitute(workSequence30_00);
            workSequence31_01.GetModel("DressingOnArmUp_Model").SetActive(false);
            workSequence31_01.GetModel("DressingOnArmDown_Model").SetActive(true);
            workSequenceList.Add(workSequence31_01);

            // Initialize Worksequence 32_00 - lower bed
            WorkSequence workSequence32_00 = new WorkSequence("workSequence32_00");
            workSequence32_00.Substitute(workSequence31_01);
            workSequence32_00.bedIsUp = false;
            workSequence32_00.SetAllowedToUse("Safebox");
            workSequenceList.Add(workSequence32_00);


            //---------------
            // Postprocessing
            //---------------


            // Initialize Worksequence 33_00 - take safebox
            WorkSequence workSequence33_00 = new WorkSequence("workSequence33_00");
            workSequence33_00.Substitute(workSequence32_00);
            workSequence33_00.GetUsableObject("Safebox").SetColliderActive(false);
            workSequence33_00.SetItemAtHand("Safebox");
            workSequence33_00.SetAllowedToUse("Hitplane_Stored_Safebox");
            workSequenceList.Add(workSequence33_00);

            // Initialize Worksequence 33_01 - put safebox in cabinet
            WorkSequence workSequence33_01 = new WorkSequence("workSequence33_01");
            workSequence33_01.Substitute(workSequence33_00);
            workSequence33_01.PlaceObject("Safebox", "ObjectPlace_Stored_Safebox");
            workSequence33_01.SetItemAtHand("");
            workSequence33_01.SetAllowedToUse("Fixation");
            workSequenceList.Add(workSequence33_01);

            // Initialize Worksequence 33_02 - take fixation
            WorkSequence workSequence33_02 = new WorkSequence("workSequence33_02");
            workSequence33_02.Substitute(workSequence33_01);
            workSequence33_02.GetUsableObject("Fixation").SetColliderActive(false);
            workSequence33_02.SetItemAtHand("Fixation");
            workSequence33_02.GetHitplane("Hitplane_Stored_Fixation").SetActive(true);
            workSequence33_02.SetAllowedToUse("Hitplane_Stored_Fixation");
            workSequenceList.Add(workSequence33_02);

            // Initialize Worksequence 33_03 - put fixation in cabinet
            WorkSequence workSequence33_03 = new WorkSequence("workSequence33_03");
            workSequence33_03.Substitute(workSequence33_02);
            workSequence33_03.PlaceObject("Fixation", "ObjectPlace_Stored_Fixation");
            workSequence33_03.GetHitplane("Hitplane_Stored_Fixation").SetActive(false);
            workSequence33_03.SetItemAtHand("");
            workSequence33_03.SetAllowedToUse("WoundDisinfectant");
            workSequenceList.Add(workSequence33_03);

            // Initialize Worksequence 33_04 - take WoundDisinfectant
            WorkSequence workSequence33_04 = new WorkSequence("workSequence33_04");
            workSequence33_04.Substitute(workSequence33_03);
            workSequence33_04.GetUsableObject("WoundDisinfectant").SetColliderActive(false);
            workSequence33_04.SetItemAtHand("WoundDisinfectant");
            workSequence33_04.GetHitplane("Hitplane_Stored_WoundDisinfectant").SetActive(true);
            workSequence33_04.SetAllowedToUse("Hitplane_Stored_WoundDisinfectant");
            workSequenceList.Add(workSequence33_04);

            // Initialize Worksequence 33_05 - put WoundDisinfectant in cabinet
            WorkSequence workSequence33_05 = new WorkSequence("workSequence33_05");
            workSequence33_05.Substitute(workSequence33_04);
            workSequence33_05.PlaceObject("WoundDisinfectant", "ObjectPlace_Stored_WoundDisinfectant");
            workSequence33_05.GetHitplane("Hitplane_Stored_WoundDisinfectant").SetActive(false);
            workSequence33_05.SetItemAtHand("");
            workSequence33_05.SetAllowedToUse("Mask");
            workSequenceList.Add(workSequence33_05);

            // Initialize Worksequence 33_06 - take mask
            WorkSequence workSequence33_06 = new WorkSequence("workSequence33_06");
            workSequence33_06.Substitute(workSequence33_05);
            workSequence33_06.GetUsableObject("Mask").SetColliderActive(false);
            workSequence33_06.SetItemAtHand("Mask");
            workSequence33_06.GetHitplane("Hitplane_Stored_Mask").SetActive(true);
            workSequence33_06.SetAllowedToUse("Hitplane_Stored_Mask");
            workSequenceList.Add(workSequence33_06);

            // Initialize Worksequence 33_07 - put mask in cabinet
            WorkSequence workSequence33_07 = new WorkSequence("workSequence33_07");
            workSequence33_07.Substitute(workSequence33_06);
            workSequence33_07.PlaceObject("Mask", "ObjectPlace_Stored_Mask");
            workSequence33_07.GetHitplane("Hitplane_Stored_Mask").SetActive(false);
            workSequence33_07.SetItemAtHand("");
            workSequence33_07.SetAllowedToUse("Compress");
            workSequenceList.Add(workSequence33_07);

            // Initialize Worksequence 33_08 - take compress
            WorkSequence workSequence33_08 = new WorkSequence("workSequence33_08");
            workSequence33_08.Substitute(workSequence33_07);
            workSequence33_08.GetUsableObject("Compress").SetColliderActive(false);
            workSequence33_08.SetItemAtHand("Compress");
            workSequence33_08.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence33_08);

            // Initialize Worksequence 33_09 - throw compress away
            WorkSequence workSequence33_09 = new WorkSequence("workSequence33_09");
            workSequence33_09.Substitute(workSequence33_08);
            workSequence33_09.GetUsableObject("Compress").SetActive(false);
            workSequence33_09.SetItemAtHand("");
            workSequence33_09.SetAllowedToUse("Swab");
            workSequenceList.Add(workSequence33_09);

            // Initialize Worksequence 33_10 - take swab
            WorkSequence workSequence33_10 = new WorkSequence("workSequence33_10");
            workSequence33_10.Substitute(workSequence33_09);
            workSequence33_10.GetUsableObject("Swab").SetColliderActive(false);
            workSequence33_10.SetItemAtHand("Swab");
            workSequence33_10.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence33_10);

            // Initialize Worksequence 33_11 - throw swab away
            WorkSequence workSequence33_11 = new WorkSequence("workSequence33_11");
            workSequence33_11.Substitute(workSequence33_10);
            workSequence33_11.GetUsableObject("Swab").SetActive(false);
            workSequence33_11.SetItemAtHand("");
            workSequence33_11.SetAllowedToUse("Tweezer");
            workSequenceList.Add(workSequence33_11);

            // Initialize Worksequence 33_12 - take tweezer
            WorkSequence workSequence33_12 = new WorkSequence("workSequence33_12");
            workSequence33_12.Substitute(workSequence33_11);
            workSequence33_12.GetUsableObject("Tweezer").SetColliderActive(false);
            workSequence33_12.SetItemAtHand("Tweezer");
            workSequence33_12.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence33_12);

            // Initialize Worksequence 34_00 - throw tweezer away
            WorkSequence workSequence34_00 = new WorkSequence("workSequence34_00");
            workSequence34_00.Substitute(workSequence33_12);
            workSequence34_00.GetUsableObject("Tweezer").SetActive(false);
            workSequence34_00.SetItemAtHand("");
            workSequence34_00.SetAllowedToUse("PlaneDisinfectant");
            workSequenceList.Add(workSequence34_00);

            // Initialize Worksequence 34_01 - take tissue
            WorkSequence workSequence34_01 = new WorkSequence("workSequence34_01");
            workSequence34_01.Substitute(workSequence34_00);
            workSequence34_01.lidIsUp = false;
            workSequence34_01.GetModel("Tissue_Model").SetActive(true);
            workSequence34_01.SetItemAtHand("Tissue");
            workSequence34_01.GetHitplane("Hitplane_Workplate_Big").SetActive(true);
            workSequence34_01.SetAllowedToUse("Hitplane_Workplate_Big");
            workSequenceList.Add(workSequence34_01);

            // Initialize Worksequence 35_00 - put material on small workplate
            WorkSequence workSequence35_00 = new WorkSequence("workSequence35_00");
            workSequence35_00.Substitute(workSequence34_01);
            workSequence35_00.SetItemAtHand("Tissue");
            workSequence35_00.PlaceObject("Gloves", "ObjectPlace_Gloves_cleaning");
            workSequence35_00.PlaceObject("HandDisinfectant", "ObjectPlace_HandDisinfectant_cleaning");
            workSequence35_00.SetAllowedToUse("Hitplane_Workplate_Big");
            workSequenceList.Add(workSequence35_00);

            // Initialize Worksequence 35_01 - wipe big workplate
            WorkSequence workSequence35_01 = new WorkSequence("workSequence35_01");
            workSequence35_01.Substitute(workSequence35_00);
            workSequence35_01.SetItemAtHand("Tissue");
            workSequence35_01.SetAllowedToUse("Hitplane_Workplate_Big");
            workSequenceList.Add(workSequence35_01);

            // Initialize Worksequence 35_02 - wipe big workplate
            WorkSequence workSequence35_02 = new WorkSequence("workSequence35_02");
            workSequence35_02.Substitute(workSequence35_01);
            workSequence35_02.GetHitplane("Hitplane_Workplate_Big").SetActive(false);
            workSequence35_02.GetHitplane("Hitplane_Workplate_Small").SetActive(true);
            workSequence35_02.PlaceObject("Gloves", "ObjectPlace_Gloves");
            workSequence35_02.PlaceObject("HandDisinfectant", "ObjectPlace_HandDisinfectant");
            workSequence35_02.PlaceObject("PlaneDisinfectant", "ObjectPlace_PlaneDisinfectant_cleaning");
            workSequence35_02.SetItemAtHand("Tissue");
            workSequence35_02.SetAllowedToUse("Hitplane_Workplate_Small");
            workSequenceList.Add(workSequence35_02);

            // Initialize Worksequence 35_03 - put material on standard
            WorkSequence workSequence35_03 = new WorkSequence("workSequence35_03");
            workSequence35_03.Substitute(workSequence35_02);
            workSequence35_03.SetItemAtHand("Tissue");
            workSequence35_03.SetAllowedToUse("Hitplane_Workplate_Small");
            workSequenceList.Add(workSequence35_03);

            // Initialize Worksequence 36_00 - wipe small workplate
            WorkSequence workSequence36_00 = new WorkSequence("workSequence36_00");
            workSequence36_00.Substitute(workSequence35_03);
            workSequence36_00.SetItemAtHand("Tissue");
            workSequence36_00.PlaceObject("PlaneDisinfectant", "ObjectPlace_PlaneDisinfectant");
            workSequence36_00.GetHitplane("Hitplane_Workplate_Small").SetActive(false);
            workSequence36_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence36_00);

            // Initialize Worksequence 37_00 - throw away tissue
            WorkSequence workSequence37_00 = new WorkSequence("workSequence37_00");
            workSequence37_00.Substitute(workSequence36_00);
            workSequence37_00.GetModel("Tissue_Model").SetActive(false);
            workSequence37_00.SetItemAtHand("");
            workSequence37_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence37_00);

            // Initialize Worksequence 38_00 - throw away gloves
            WorkSequence workSequence38_00 = new WorkSequence("workSequence38_00");
            workSequence38_00.Substitute(workSequence37_00);
            workSequence38_00.iconList.Hands();
            workSequence38_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence38_00);

            // Initialize Worksequence 39_00 - throw away apron
            WorkSequence workSequence39_00 = new WorkSequence("workSequence39_00");
            workSequence39_00.Substitute(workSequence38_00);
            workSequence39_00.iconList.Body();
            workSequence39_00.SetAllowedToUse("HandDisinfectant");
            workSequenceList.Add(workSequence39_00);

            // Initialize Worksequence 139_00 - disinfect hands
            WorkSequence workSequence139_00 = new WorkSequence("workSequence139_00");
            workSequence139_00.Substitute(workSequence39_00);
            workSequence139_00.iconList.HandsDisinfected();
            workSequence139_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence139_00);

            // Initialize Worksequence 40_00 - take rubbishbag
            WorkSequence workSequence40_00 = new WorkSequence("workSequence40_00");
            workSequence40_00.Substitute(workSequence139_00);
            workSequence40_00.GetModel("CelluloseInRubbish_Model").SetActive(false);
            workSequence40_00.GetModel("DishInRubbish_Model").SetActive(false);
            workSequence40_00.GetModel("SwabInRubbish_Model").SetActive(false);
            workSequence40_00.GetModel("OldDressingInDishInRubbish_Model").SetActive(false);
            workSequence40_00.GetModel("Bag_Model").SetActive(false);
            workSequence40_00.SetAllowedToUse("Rubbish");
            workSequenceList.Add(workSequence40_00);

            // Initialize Worksequence 41_00 - place new rubbishbag
            WorkSequence workSequence41_00 = new WorkSequence("workSequence41_00");
            workSequence41_00.Substitute(workSequence40_00);
            workSequence41_00.GetModel("Bag_Model").SetActive(true);
            workSequence41_00.SetAllowedToUse("Clipboard");
            workSequenceList.Add(workSequence41_00);
            
            // Initialize Worksequence 42_00 - note treatment
            WorkSequence workSequence42_00 = new WorkSequence("workSequence42_00");
            workSequence42_00.Substitute(workSequence41_00);
            workSequence42_00.SetAllowedToUse("");
            workSequenceList.Add(workSequence42_00);
        }
    }
}
