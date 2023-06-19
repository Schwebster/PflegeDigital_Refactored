using Assets.Scripts.Lists;
using Assets.Scripts.Main;
using Assets.Scripts.ObjectClasses;
using Assets.Scripts.ObjectClasses.InteractClasses;
using Assets.Scripts.PlayerClasses;
using Assets.Scripts.WorksequenceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.TooltipClasses
{

    internal class TooltipManager
    {
        private Tooltip _tooltip;
        private Bed _bed;
        private Doors _door;

        public TooltipManager() {    
            _bed = GameObject.Find("Scene/Objects/Bed").GetComponent<Bed>();
            _door = GameObject.Find("Scene/Objects/FirstAidCabinet").GetComponent<Doors>();
            _tooltip = new Tooltip();
        }

        public void UpdateTooltip(GameObject itemAtSight, string itemAtHand, string workSequenceID)
        {
            if (itemAtHand.Equals(""))
            {
                switch (itemAtSight.name)
                {
                    case "Apron":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("MountApron"));
                        break;
                    case "Gloves":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeGloves"));
                        break;
                    case "Dish":
                        if (workSequenceID.Equals("workSequence23_03") || workSequenceID.Equals("workSequence23_07")) 
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowSwab"));
                        else if (workSequenceID.Equals("workSequence13_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeDishCellulose"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeDish"));
                        break;
                    case "Cellulose":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeCellulose"));
                        break;
                    case "OldDressing":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeOldDressing"));
                        break;
                    case "Swab":
                        if (workSequenceID.Equals("workSequence10_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenSwab"));
                        else if (workSequenceID.Equals("workSequence33_09")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeOldPack"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeSwab"));
                        break;
                    case "Compress":
                       if (workSequenceID.Equals("workSequence10_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenCompress"));
                       else if (workSequenceID.Equals("workSequence33_07")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeOldPack"));
                       else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeCompress"));
                        break;
                    case "Tweezer":
                        if (workSequenceID.Equals("workSequence10_02")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenTweezer"));
                        else if (workSequenceID.Equals("workSequence33_11")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeOldPack"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeTweezer"));
                        break;
                    case "Fixation":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeFixation"));
                        break;
                    case "FixationTape":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeFixationTape"));
                        break;
                    case "Scissors":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeScissors"));
                        break;
                    case "WoundDisinfectant":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeWoundDesinfectant"));
                        break;
                    case "PlaneDisinfectant":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakePlaneDesinfectant"));
                        break;
                    case "Mask":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeMask"));
                        break;
                    case "Safebox":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeSafebox"));
                        break;
                    case "Bed":
                        if (workSequenceID.Equals("workSequence2_00"))
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("BedUp"));
                        else if (workSequenceID.Equals("workSequence31_00")) 
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("BedDown"));
                        else _tooltip.HideTooltip();
                        break;
                    case "HandDisinfectant":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("DesinfectHands"));
                        break;
                    case "DoorL":
                        if (_door.GetBoolDoorsAreOpen()) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("CloseDoors"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenDoors"));
                        break;
                    case "DoorL2":
                        if (_door.GetBoolDoorsAreOpen()) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("CloseDoors"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenDoors"));
                        break;
                    case "DoorR":
                        if (_door.GetBoolDoorsAreOpen()) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("CloseDoors"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenDoors"));
                        break;
                    case "DoorR2":
                        if (_door.GetBoolDoorsAreOpen()) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("CloseDoors"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("OpenDoors"));
                        break;
                    case "Rubbish":
                        if (workSequenceID.Equals("workSequence5_00") || workSequenceID.Equals("workSequence18_00") ||
                            workSequenceID.Equals("workSequence28_00") || workSequenceID.Equals("workSequence37_00")) 
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowGloves"));
                        else if (workSequenceID.Equals("workSequence38_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowApron"));
                        else if (workSequenceID.Equals("workSequence27_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("DisposeRubbish"));
                        else if (workSequenceID.Equals("workSequence139_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("Rubbish"));
                        else if (workSequenceID.Equals("workSequence40_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("PlaceBag"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Hitplane_CelluloseOnBed":
                        if (workSequenceID.Equals("workSequence16_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("PlaceCelluloseArm"));
                        else if (workSequenceID.Equals("workSequence27_02")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeCellulose"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Hitplane_Arm":
                        if (workSequenceID.Equals("workSequence23_01") || workSequenceID.Equals("workSequence23_05")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("cleanWound"));
                        else if (workSequenceID.Equals("workSequence20_00")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("Wound"));
                        else if (workSequenceID.Equals("workSequence25_01")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("placeCompressWound"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Clipboard":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("Documentation"));
                        break;
                    default:
                        if (itemAtSight.CompareTag("ObjectWithTooltip")) _tooltip.ShowTooltip("[DEFAULT]");
                        else _tooltip.HideTooltip();
                        break;
                }              
            }
            else if (itemAtSight.CompareTag("Hitplane"))
            {
                switch (itemAtHand)
                {
                    case "Tissue":
                        if ((itemAtSight.name.Equals("Hitplane_Workplate_Big") || itemAtSight.name.Equals("Hitplane_Workplate_Small")) 
                            && ((workSequenceID.Equals("workSequence4_00") || 
                            (workSequenceID.Equals("workSequence34_01")) ||
                            (workSequenceID.Equals("workSequence35_01")) ||
                            (workSequenceID.Equals("workSequence35_03")) ||
                            (workSequenceID.Equals("workSequence4_00")) ||
                            (workSequenceID.Equals("workSequence4_02")) ||
                            (workSequenceID.Equals("workSequence4_04"))))) 
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("RegroupItems"));
                        else if (itemAtSight.name.Equals("Hitplane_Workplate_Big") || itemAtSight.name.Equals("Hitplane_Workplate_Small"))
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("DesinfectPlane"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Dish":
                        if (itemAtSight.name.Equals("Hitplane_Dish")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayDish"));
                        else if (itemAtSight.name.Equals("Hitplane_DishOnBed")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayDishCellulose"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Cellulose":
                        if (itemAtSight.name.Equals("Hitplane_Cellulose")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayCellulose"));
                        else if (itemAtSight.name.Equals("Hitplane_CelluloseOnBed")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("PlaceCelluloseArm"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Swab":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LaySwab"));
                        break;
                    case "Compress":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayCompress"));
                        break;
                    case "CompressAtHand":
                        if (itemAtSight.name.Equals("Hitplane_DishOnBed")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayCompress"));
                        else if (itemAtSight.name.Equals("Hitplane_Arm")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("placeCompressWound"));
                        else 
                        _tooltip.HideTooltip();
                        break;
                    case "Fixation":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayFixation"));
                        break;
                    case "FixationTape":
                        if (itemAtSight.name.Equals("Hitplane_DishOnBed")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("PlaceTape"));
                        else _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayFixationTape"));
                        break;
                    case "Scissors":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayScissors"));
                        break;
                    case "Tweezer":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayTweezer"));
                        break;
                    case "WoundDisinfectant":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayWoundDisinfectant"));
                        break;
                    case "Mask":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayMask"));
                        break;
                    case "Safebox":
                        _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LaySafebox"));
                        break;
                    case "TweezerAtHand":
                        if (itemAtSight.name.Equals("Hitplane_Arm") && 
                            (workSequenceID.Equals("workSequence20_00") || workSequenceID.Equals("workSequence23_01"))) 
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("cleanWound"));
                        else _tooltip.HideTooltip();
                        break;
                    case "OldDressing":
                        if (itemAtSight.name.Equals("Hitplane_DishOnBed")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("LayOldDressing"));
                        break;
                    default:
                        if (itemAtSight.CompareTag("ObjectWithTooltip")) _tooltip.ShowTooltip("[DEFAULT]");
                        else _tooltip.HideTooltip();
                        break;
                }
            }
            else if (itemAtSight.CompareTag("ObjectWithTooltip"))
            {
                switch (itemAtSight.name)
                {
                    case "Dish":
                        if (workSequenceID.Equals("workSequence23_03") || workSequenceID.Equals("workSequence23_07"))
                            _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowSwab"));
                        else if (workSequenceID.Equals("workSequence17_01")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowOldDressing"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Swab":
                        if (itemAtHand.Equals("WoundDisinfectant")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("SaturateSwab"));
                        else if (itemAtHand.Equals("TweezerAtHand")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("TakeSwabTweezer"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Fixation":
                        if (itemAtHand.Equals("Scissors")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("CutTape"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Safebox":
                        if (itemAtHand.Equals("Scissors")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("SecureScissors"));
                        else if (itemAtHand.Equals("TweezerAtHand")) _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("SecureTweezer"));
                        else _tooltip.HideTooltip();
                        break;
                    case "Rubbish":
                        switch (itemAtHand)
                        {
                            case "Cellulose":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowCellulose"));
                                break;
                            case "Dish":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowDish"));
                                break;
                            case "OldDressing":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowOldDressing"));
                                break;
                            case "Swab":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowOldPack"));
                                break;
                            case "Compress":
                               _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowOldPack"));
                                break;
                            case "Fixation":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowFixation"));
                                break;
                            case "FixationTape":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowFixationTape"));
                                break;
                            case "Scissors":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowScissors"));
                                break;
                            case "ThrowTweezer":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowTweezer"));
                                break;
                            case "WoundDesinfectant":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowWoundDesinfectant"));
                                break;
                            case "Tissue":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowPlaneDesinfectant"));
                                break;
                            case "Mask":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowMask"));
                                break;
                            case "Safebox":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowSafebox"));
                                break;
                            case "Tweezer":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowOldPack"));
                                break;
                            case "TweezerAtHand":
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("ThrowTweezer"));
                                break;
                            default:
                                _tooltip.ShowTooltip(LocalizationManager.Instance.GetText("Throw"));
                                break;
                        }
                        break;
                    default:
                            _tooltip.HideTooltip();
                        break;
                }
            }
            else _tooltip.HideTooltip();
        }
    }
}

