using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using Assets.Scripts.TooltipClasses;
using UnityEngine;
using Assets.Scripts;
using System;
using Assets.Scripts.Menu;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Main
{
    public class MainScene : MonoBehaviour
    {
        public WorksequenceListLoadManager workSequenceListLoadManager { get; set; }
        public InputLoadManager inputLoadManager { get; private set; }

        private Player _player;
        private CastRaycast _raycast;

        private Doors _doors;
        private Bed _bed;
        private Error _error;
        private Heading _headingText;
        private WorksequenceText _worksequenceText;
        private GameObject disinfectLid, disinfectTissue,
            tissue, compress, swab, tweezer, tweezerAtWound, 
            woundDisinfectant, woundDisinfectantLid;

        private float animationTime;

        private WorkSequence currentWorkSequence;
        private bool mouseClick, mouseDoubleClick, stopHoldingItem = false;
        private float mouseClickTimer, errorTimer;


        void Awake()
        {
            AwakeGameObjects();
            workSequenceListLoadManager = new WorksequenceListLoadManager();
            inputLoadManager = new InputLoadManager();
            _player.AwakePlayer();
            _raycast = new CastRaycast();
            _error = new Error();
            _headingText = new Heading();
            _worksequenceText = new WorksequenceText();

            LoadWorkSequence("workSequence0_00");
        }
        void Update()
        {
            inputLoadManager.UpdateValues();
            _player.UpdatePlayer(_raycast);
            MouseClick();
            HoldItem(currentWorkSequence.itemAtHand);
            
            Main();

            DoorAnimation();

            SaturateSwab();
            OpenPlanedisinfectantLid();
            ClosePlanedisinfectantLid();
            BedAnimation();
            CleanWound();

            Error();

            ClickTimer();
        }

        public void Main()
        {
            if (mouseClick && !mouseDoubleClick &&
                _raycast.itemAtSight.GetComponent<Collider>().enabled &&
                !_raycast.itemAtSight.GetComponent<Collider>().CompareTag("Untagged") &&
                !_raycast.itemAtSight.GetComponent<Collider>().CompareTag("Door") &&
                Time.timeScale != 0)
            {
                mouseDoubleClick = true;
                mouseClickTimer = 0;

                if (_raycast.itemAtSight.name.Equals(currentWorkSequence.objectAllowedToUse))
                {
                    switch (currentWorkSequence.sequenceID)
                    {
                        // click on HandDisinfectant
                        case ("workSequence0_00"):
                            LoadWorkSequence("workSequence1_00");
                            break;

                        // click on Gloves
                        case ("workSequence1_00"):
                            LoadWorkSequence("workSequence2_00");
                            break;

                        // click on Bed
                        case ("workSequence2_00"):
                            LoadWorkSequence("workSequence3_00");
                            break;

                        // wait for animation
                        case ("workSequence3_00"):
                            animationTime = 0;
                            break;

                        // click on PlaneDisinfectant
                        case ("workSequence3_01"):
                            LoadWorkSequence("workSequence4_00");
                            break;

                        // click on Hitplane_Workplate_Big
                        case ("workSequence4_00"):
                            LoadWorkSequence("workSequence4_01");
                            break;

                        // click on Hitplane_Workplate_Big
                        case ("workSequence4_01"):
                            tissue.GetComponent<Animation>().Play("Tissue_big");
                            //currentWorkSequence.objectAnimationList.GetAnimation("Tissue_big").Play();
                            LoadWorkSequence("workSequence4_02");
                            break;

                        // click on Hitplane_Workplate_Big
                        case ("workSequence4_02"):
                            LoadWorkSequence("workSequence4_03");
                            break;

                        // click on Hitplane_Workplate_Small
                        case ("workSequence4_03"):
                            tissue.GetComponent<Animation>().Play("Tissue_small");
                            //currentWorkSequence.objectAnimationList.GetAnimation("Tissue_small").Play();
                            LoadWorkSequence("workSequence4_04");
                            break;

                        // click on Hitplane_Workplate_Small
                        case ("workSequence4_04"):
                            LoadWorkSequence("workSequence104_05");
                            break;

                        // click on Rubbish
                        case ("workSequence104_05"):
                            LoadWorkSequence("workSequence5_00");
                            break;

                        // click on Rubbish
                        case ("workSequence5_00"):
                            LoadWorkSequence("workSequence6_00");
                            break;

                        // click on HandDisinfectant
                        case ("workSequence6_00"):
                            LoadWorkSequence("workSequence7_00");
                            break;

                        // click on Apron
                        case ("workSequence7_00"):
                            LoadWorkSequence("workSequence8_00");
                            break;

                        // click on Safebox
                        case ("workSequence8_00"):
                            LoadWorkSequence("workSequence9_00");
                            break;

                        //-------------------
                        // Put items on plate
                        //-------------------


                        // click on Hitplane_Safebox
                        case ("workSequence9_00"):
                            LoadWorkSequence("workSequence9_01");
                            break;

                        // click on Fixation
                        case ("workSequence9_01"):
                            LoadWorkSequence("workSequence9_02");
                            break;

                        // click on Hitplane_Fixation
                        case ("workSequence9_02"):
                            LoadWorkSequence("workSequence9_03");
                            break;

                        // click on WoundDisinfectant
                        case ("workSequence9_03"):
                            LoadWorkSequence("workSequence9_04");
                            break;

                        // click on Hitplane_WoundDisinfectant
                        case ("workSequence9_04"):
                            LoadWorkSequence("workSequence9_05");
                            break;

                        // click on Mask
                        case ("workSequence9_05"):
                            LoadWorkSequence("workSequence9_06");
                            break;

                        // click on Hitplane_Mask
                        case ("workSequence9_06"):
                            LoadWorkSequence("workSequence9_07");
                            break;

                        // click on Compress
                        case ("workSequence9_07"):
                            LoadWorkSequence("workSequence9_08");
                            break;

                        // click on Hitplane_Compress
                        case ("workSequence9_08"):
                            LoadWorkSequence("workSequence9_09");
                            break;

                        // click on Swab
                        case ("workSequence9_09"):
                            LoadWorkSequence("workSequence9_10");
                            break;

                        // click on Hitplane_Swab
                        case ("workSequence9_10"):
                            LoadWorkSequence("workSequence9_11");
                            break;

                        // click on Tweezer
                        case ("workSequence9_11"):
                            LoadWorkSequence("workSequence9_12");
                            break;

                        // click on Hitplane_Tweezer
                        case ("workSequence9_12"):
                            LoadWorkSequence("workSequence9_13");
                            break;

                        // click on Scissors
                        case ("workSequence9_13"):
                            LoadWorkSequence("workSequence9_14");
                            break;

                        // click on Hitplane_Scissors
                        case ("workSequence9_14"):
                            LoadWorkSequence("workSequence9_15");
                            break;

                        // click on Dish
                        case ("workSequence9_15"):
                            LoadWorkSequence("workSequence9_16");
                            break;

                        // click on Hitplane_Dish
                        case ("workSequence9_16"):
                            LoadWorkSequence("workSequence9_17");
                            break;

                        // click on Cellulose
                        case ("workSequence9_17"):
                            LoadWorkSequence("workSequence9_18");
                            break;

                        // click on Hitplane_Cellulose
                        case ("workSequence9_18"):
                            LoadWorkSequence("workSequence10_00");
                            break;

                        //-----------------
                        // Prepare material
                        //-----------------


                        // click on Compress
                        case ("workSequence10_00"):
                            compress.GetComponent<Animation>().Play("openingCompress");
                            //currentWorkSequence.objectAnimationList.GetAnimation("openingCompress").Play();
                            LoadWorkSequence("workSequence10_01");
                            break;

                        // click on Swab
                        case ("workSequence10_01"):
                            swab.GetComponent<Animation>().Play("openingSwab");
                            //currentWorkSequence.objectAnimationList.GetAnimation("openingSwab").Play();
                            LoadWorkSequence("workSequence10_02");
                            break;

                        // click on Tweezer
                        case ("workSequence10_02"):
                            tweezer.GetComponent<Animation>().Play("openingTweezer");
                            currentWorkSequence.objectAnimationList.GetAnimation("openingTweezer").Play();
                            LoadWorkSequence("workSequence11_00");
                            break;

                        // click on Scissors
                        case ("workSequence11_00"):
                            LoadWorkSequence("workSequence11_01");
                            break;

                        // click on Fixation
                        case ("workSequence11_01"):
                            LoadWorkSequence("workSequence11_02");
                            break;

                        // click on Safebox
                        case ("workSequence11_02"):
                            LoadWorkSequence("workSequence12_00");
                            break;

                        // click on WoundDisinfectant
                        case ("workSequence12_00"):
                            LoadWorkSequence("workSequence12_01");
                            break;

                        // click on Swab
                        case ("workSequence12_01"):
                            animationTime = 0;
                            LoadWorkSequence("workSequence12_02");
                            break;

                        // click on Hitplane_WoundDisinfectant
                        case ("workSequence12_02"):
                            break;

                        // click on Dish
                        case ("workSequence13_00"):
                            LoadWorkSequence("workSequence13_01");
                            break;

                        // click on Hitplane_DishOnBed
                        case ("workSequence13_01"):
                            LoadWorkSequence("workSequence14_00");
                            break;

                        // click on HandDisinfectant
                        case ("workSequence14_00"):
                            LoadWorkSequence("workSequence15_00");
                            break;

                        // click on Gloves
                        case ("workSequence15_00"):
                            LoadWorkSequence("workSequence16_00");
                            break;

                        // click on Hitplane_CelluloseOnBed
                        case ("workSequence16_00"):
                            LoadWorkSequence("workSequence17_00");
                            break;

                        // click on OldDressing 
                        case ("workSequence17_00"):
                            LoadWorkSequence("workSequence17_01");
                            break;

                        // click on Dish
                        case ("workSequence17_01"):
                            LoadWorkSequence("workSequence18_00");
                            break;

                        // click on Rubbish
                        case ("workSequence18_00"):
                            LoadWorkSequence("workSequence19_00");
                            break;

                        // click on HandsDisinfectant
                        case ("workSequence19_00"):
                            LoadWorkSequence("workSequence20_00");
                            break;

                        // click on Hitplane_Arm
                        case ("workSequence20_00"):
                            LoadWorkSequence("workSequence21_00");
                            break;

                        // click on Gloves
                        case ("workSequence21_00"):
                            LoadWorkSequence("workSequence22_00");
                            break;

                        // click on Tweezer
                        case ("workSequence22_00"):
                            LoadWorkSequence("workSequence23_00");
                            break;

                        // click on Swab
                        case ("workSequence23_00"):
                            LoadWorkSequence("workSequence23_01");
                            break;

                        // click on Hitplane_Arm
                        case ("workSequence23_01"):
                            LoadWorkSequence("workSequence23_02");
                            break;

                        // wait for animation
                        case ("workSequence23_02"):
                            break;

                        // click on Dish
                        case ("workSequence23_03"):
                            LoadWorkSequence("workSequence23_04");
                            break;

                        // click on Swab
                        case ("workSequence23_04"):
                            LoadWorkSequence("workSequence23_05");
                            break;

                        // click on Hitplane_Arm
                        case ("workSequence23_05"):
                            LoadWorkSequence("workSequence23_06");
                            break;

                        // wair for animation
                        case ("workSequence23_06"):
                            break;

                        // click on Dish
                        case ("workSequence23_07"):
                            LoadWorkSequence("workSequence24_00");
                            break;

                        // click on Safebox
                        case ("workSequence24_00"):
                            LoadWorkSequence("workSequence25_00");
                            break;

                        // click on Compress
                        case ("workSequence25_00"):
                            LoadWorkSequence("workSequence25_01");
                            break;

                        // click on Hitplane_Arm
                        case ("workSequence25_01"):
                            LoadWorkSequence("workSequence26_00");
                            break;

                        // click on FixationTape
                        case ("workSequence26_00"):
                            LoadWorkSequence("workSequence26_01");
                            break;

                        // click on Hitplane_Arm
                        case ("workSequence26_01"):
                            LoadWorkSequence("workSequence27_00");
                            break;

                        // click on Dish
                        case ("workSequence27_00"):
                            LoadWorkSequence("workSequence27_01");
                            break;

                        // click on Rubbish
                        case ("workSequence27_01"):
                            LoadWorkSequence("workSequence27_02");
                            break;

                        // click on Hitplane_CelluloseOnBed
                        case ("workSequence27_02"):
                            LoadWorkSequence("workSequence27_03");
                            break;

                        // click on Rubbish
                        case ("workSequence27_03"):
                            LoadWorkSequence("workSequence28_00");
                            break;

                        // click on Rubbish
                        case ("workSequence28_00"):
                            LoadWorkSequence("workSequence29_00");
                            break;

                        // click on HandDisinfectant
                        case ("workSequence29_00"):
                            LoadWorkSequence("workSequence30_00");
                            break;

                        // click on Gloves
                        case ("workSequence30_00"):
                            LoadWorkSequence("workSequence31_00");
                            break;

                        // click on Bed
                        case ("workSequence31_00"):
                            LoadWorkSequence("workSequence31_01");
                            break;
                            
                        // wait for Animation
                        case ("workSequence31_01"):
                            LoadWorkSequence("workSequence32_00");
                            break;

                        //---------------
                        // Postprocessing
                        //---------------


                        // click on Safebox
                        case ("workSequence32_00"):
                            LoadWorkSequence("workSequence33_00");
                            break;

                        // click on Hitplane_Stored_Safebox
                        case ("workSequence33_00"):
                            LoadWorkSequence("workSequence33_01");
                            break;

                        // click on Fixation
                        case ("workSequence33_01"):
                            LoadWorkSequence("workSequence33_02");
                            break;

                        // click on Hitplane_Stored_Fixation
                        case ("workSequence33_02"):
                            LoadWorkSequence("workSequence33_03");
                            break;

                        // click on WoundDisinfectant
                        case ("workSequence33_03"):
                            LoadWorkSequence("workSequence33_04");
                            break;

                        // click on Hitplane_Stored_WoundDisinfectant
                        case ("workSequence33_04"):
                            LoadWorkSequence("workSequence33_05");
                            break;

                        // click on Mask
                        case ("workSequence33_05"):
                            LoadWorkSequence("workSequence33_06");
                            break;

                        // click on Hitplane_Stored_Mask
                        case ("workSequence33_06"):
                            LoadWorkSequence("workSequence33_07");
                            break;

                        // click on Compress
                        case ("workSequence33_07"):
                            LoadWorkSequence("workSequence33_08");
                            break;

                        // click on Rubbish
                        case ("workSequence33_08"):
                            LoadWorkSequence("workSequence33_09");
                            break;

                        // click on Swab
                        case ("workSequence33_09"):
                            LoadWorkSequence("workSequence33_10");
                            break;

                        // click on Rubbish
                        case ("workSequence33_10"):
                            LoadWorkSequence("workSequence33_11");
                            break;

                        // click on Tweezer
                        case ("workSequence33_11"):
                            LoadWorkSequence("workSequence33_12");
                            break;

                        // click on Rubbish
                        case ("workSequence33_12"):
                            LoadWorkSequence("workSequence34_00");
                            break;

                        // click on PlaneDisinfectant
                        case ("workSequence34_00"):
                            LoadWorkSequence("workSequence34_01");
                            break;

                        // click on Hitplane_Workplate_Big
                        case ("workSequence34_01"):
                            animationTime = 0;
                            //ClosePlanedisinfectantLid();
                            LoadWorkSequence("workSequence35_00");
                            break;

                        // click on Hitplane_Workplate_Big
                        case ("workSequence35_00"):
                            tissue.GetComponent<Animation>().Play("Tissue_big");
                            //currentWorkSequence.objectAnimationList.GetAnimation("Tissue_big").Play();
                            LoadWorkSequence("workSequence35_01");
                            break;

                        // click on Hitplane_Workplate_Small
                        case ("workSequence35_01"):
                            LoadWorkSequence("workSequence35_02");
                            break;

                        // click on Hitplane_Workplate_Small
                        case ("workSequence35_02"):
                            tissue.GetComponent<Animation>().Play("Tissue_small");
                            //currentWorkSequence.objectAnimationList.GetAnimation("Tissue_small").Play();
                            LoadWorkSequence("workSequence35_03");
                            break;

                        // click on Hitplane_Workplate_Small
                        case ("workSequence35_03"):
                            LoadWorkSequence("workSequence36_00");
                            break;

                        // click on Rubbish
                        case ("workSequence36_00"):
                            LoadWorkSequence("workSequence37_00");
                            break;

                        // click on Rubbish
                        case ("workSequence37_00"):
                            LoadWorkSequence("workSequence38_00");
                            break;

                        // click on Rubbish
                        case ("workSequence38_00"):
                            LoadWorkSequence("workSequence39_00");
                            break;

                        // click on Rubbish
                        case ("workSequence39_00"):
                            LoadWorkSequence("workSequence139_00");
                            break;

                        // click on HandDisinfectant
                        case ("workSequence139_00"):
                            LoadWorkSequence("workSequence40_00");
                            break;

                        // click on Rubbish
                        case ("workSequence40_00"):
                            LoadWorkSequence("workSequence41_00");
                            break;

                        // click on Clipboard
                        case ("workSequence41_00"):
                            LoadWorkSequence("workSequence42_00");
                            SceneManager.LoadScene("StartMenu");
                            break;
                    }
                }
                else
                {
                    errorTimer = 0;
                    _error.errorCount++;
                    _error.UpdateErrorCounter();
                    if (_raycast.itemAtSight.GetComponent<Collider>().CompareTag("ObjectWithTooltip")){
                        _error.ShowError(LocalizationManager.Instance.GetText("Error"));
                    }
                    else if (_raycast.itemAtSight.GetComponent<Collider>().CompareTag("Hitplane"))
                    {
                        _error.ShowError(LocalizationManager.Instance.GetText("ErrorPlace"));
                    }
                }
            }
        }

        public void LoadWorkSequence(string workSequence)
        {
            workSequenceListLoadManager.GetWorkSequence(workSequence).Initialize();
            currentWorkSequence = workSequenceListLoadManager.GetWorkSequence(workSequence);
            _raycast.SetItemAtHand(currentWorkSequence.itemAtHand, currentWorkSequence.sequenceID);

            // checks if bed has to be up or down
            if (currentWorkSequence.bedIsUp) { _bed.Up(); }
            else { _bed.Down(); }

            // cheacks if lid of planedisinfectant has to be open or closed
            if (currentWorkSequence.lidIsUp)
            {
                disinfectLid.transform.localRotation = new Quaternion(-1, 0, 0, 0);
                disinfectTissue.transform.localScale = new Vector3(100, 100, 100);
            }
            else
            {
                disinfectLid.transform.localRotation = new Quaternion(-0.7f, 0, 0, 0.7f);
                disinfectTissue.transform.localScale = new Vector3(100, 100, 1);
            }

            // sets text of heading for worksequence in HUD
            _headingText.UpdateHeadingText(currentWorkSequence);

            // sets text of current worksequence in HUD
            _worksequenceText.UpdateWorksequenceText(currentWorkSequence);
        }
        private void AwakeGameObjects()
        {
            _doors = GameObject.Find("Scene/Objects/FirstAidCabinet").GetComponent<Doors>();
            _bed = GameObject.Find("Scene/Objects/Bed/Bed_Model/Bed").GetComponent<Bed>();
            tissue = GameObject.Find("Scene/Objects/TooltipObjects/Tissue");
            disinfectLid = GameObject.Find("Scene/Objects/TooltipObjects/PlaneDisinfectant/PlaneDisinfectant_Model/Lid");
            disinfectTissue = GameObject.Find("Scene/Objects/TooltipObjects/PlaneDisinfectant/PlaneDisinfectant_Model/Tissue");
            woundDisinfectant = GameObject.Find("Scene/Objects/TooltipObjects/WoundDisinfectant");;
            compress = GameObject.Find("Scene/Objects/TooltipObjects/Compress/Compress_Model");
            swab = GameObject.Find("Scene/Objects/TooltipObjects/Swab/Swab_Model");
            tweezerAtWound = GameObject.Find("Scene/Objects/Bed/Bed_Model/Objects_Bed/TweezerAtWound");
            tweezer = GameObject.Find("Scene/Objects/TooltipObjects/Tweezer/Tweezer_Model");
            woundDisinfectantLid = GameObject.Find("Scene/Objects/TooltipObjects/WoundDisinfectant/WoundDisinfectant_Model/Flip-Top");
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        private void MouseClick()
        {
            if (inputLoadManager.Action())
            {
                mouseClick = true;
            }
        }
        private void ClickTimer()
        {
            mouseClick = false;
            mouseClickTimer += Time.deltaTime;

            if (mouseClickTimer > 1 && mouseDoubleClick)
            {
                mouseDoubleClick = false;
            }
        }
        private void HoldItem(string name)
        {
            if (!name.Equals("") && !stopHoldingItem)
            {
                GameObject go = currentWorkSequence.items.Item(name);

                if (go != null)
                {
                    go.transform.position = Camera.main.transform.position +
                        Camera.main.transform.forward * 1;
                    go.transform.Translate(new Vector3(0, -0.2f, -0.5f));
                    go.transform.rotation = new Quaternion(
                        0.0f, Camera.main.transform.rotation.y,
                        0.0f, Camera.main.transform.rotation.w);
                }
            }
        }
        private void Error()
        {
            if (errorTimer <= 1)
            {
                errorTimer += Time.deltaTime;
                if (errorTimer >= 1)
                {
                    _error.HideError();
                }
            }
        }

        // Animations
        private void DoorAnimation()
        {
            if (_raycast.itemAtSight.CompareTag("Door") &&
                mouseClick &&
                !mouseDoubleClick &&
                Time.timeScale != 0)
            {
                Debug.Log("Doors anmation.");
                mouseDoubleClick = true;
                mouseClickTimer = 0;

                if (!_doors.doorsAreOpen && !_doors.AnimationIsPLaying())
                {
                    _doors.OpenAnimation();
                }
                else if (_doors.doorsAreOpen && !_doors.AnimationIsPLaying())
                {
                    _doors.CloseAnimation();
                }
            }
        }
        private void BedAnimation()
        {
            if (currentWorkSequence.sequenceID.Equals("workSequence3_00"))
            {
                animationTime += Time.deltaTime;
                _bed.transform.position = Vector3.Lerp(_bed.down, _bed.up, animationTime);

                if (_bed.transform.position == _bed.up)
                {
                    LoadWorkSequence("workSequence3_01");
                }
            }
            if (currentWorkSequence.sequenceID.Equals("workSequence31_01"))
            {
                animationTime += Time.deltaTime;
                _bed.transform.position = Vector3.Lerp(_bed.up, _bed.down, animationTime);

                if (_bed.transform.position == _bed.down)
                {
                    LoadWorkSequence("workSequence32_00");
                }
            }

        }
        private void CleanWound()
        {
            if (currentWorkSequence.sequenceID.Equals("workSequence23_02") || currentWorkSequence.sequenceID.Equals("workSequence23_06"))
            {
                if (!stopHoldingItem)
                {
                    tweezerAtWound.GetComponent<Animation>().Play();
                    stopHoldingItem = true;
                }

                if (!tweezerAtWound.GetComponent<Animation>().isPlaying && stopHoldingItem)
                {
                    stopHoldingItem = false;

                    if (currentWorkSequence.sequenceID.Equals("workSequence23_02"))
                    {
                        LoadWorkSequence("workSequence23_03");
                    }
                    else if (currentWorkSequence.sequenceID.Equals("workSequence23_06"))
                        LoadWorkSequence("workSequence23_07");
                }
            }
        }
        private void SaturateSwab()
        {
            //currentWorkSequence.objectAnimationList.GetAnimation("Tupfer_traenken").Play();
            if (currentWorkSequence.sequenceID.Equals("workSequence12_02"))
            {
                // open lid
                animationTime += Time.deltaTime;
                woundDisinfectantLid.transform.localRotation = Quaternion.Lerp(new Quaternion(-0.7f, 0, 0, 0.7f), new Quaternion(-1, 0, 0, 0), animationTime);


                if (woundDisinfectantLid.transform.localRotation == new Quaternion(-1, 0, 0, 0) && !stopHoldingItem)
                {
                    woundDisinfectant.transform.position = swab.transform.position + new Vector3(0, 0.2f, -0.2f);
                    woundDisinfectant.GetComponent<Animation>().Play("Tupfer_traenken");
                    stopHoldingItem = true;
                }

                if (!woundDisinfectant.GetComponent<Animation>().isPlaying && stopHoldingItem)
                {

                    stopHoldingItem = false;
                    woundDisinfectantLid.transform.localRotation = new Quaternion(-0.7f, 0, 0, 0.7f);
                    LoadWorkSequence("workSequence13_00");
                }


            }
        }
        private void OpenPlanedisinfectantLid()
        {
            if (currentWorkSequence.sequenceID.Equals("workSequence4_00"))
            {
                // open lid
                animationTime += Time.deltaTime;
                Quaternion animRotStart = new Quaternion(-0.7f, 0, 0, 0.7f);
                Quaternion animRotEnd = new Quaternion(-1, 0, 0, 0);
                disinfectLid.transform.localRotation = Quaternion.Lerp(animRotStart, animRotEnd, animationTime);
                disinfectTissue.transform.localScale = Vector3.Lerp(new Vector3(100, 100, 1), new Vector3(100, 100, 100), animationTime);
            }
        }
        private void ClosePlanedisinfectantLid()
        {
            if (currentWorkSequence.sequenceID.Equals("workSequence34_01"))
            {
                // close lid
                animationTime += Time.deltaTime;

                Quaternion animRotStart = new Quaternion(-1, 0, 0, 0);
                Quaternion animRotEnd = new Quaternion(-0.7f, 0, 0, 0.7f);
                disinfectLid.transform.localRotation = Quaternion.Lerp(animRotStart, animRotEnd, animationTime);
                disinfectTissue.transform.localScale = Vector3.Lerp(new Vector3(100, 100, 100), new Vector3(100, 100, 1), animationTime);
            }
        }
    }
}
