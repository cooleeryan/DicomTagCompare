using System;

namespace TagCompare.Dict
{
    public enum VR
    {
        NONE = 0x0000,
        AE = 0x4145,
        AS = 0x4153,
        AT = 0x4154,
        CS = 0x4353,
        DA = 0x4441,
        DS = 0x4453,
        DT = 0x4454,
        FL = 0x464C,
        FD = 0x4644,
        IS = 0x4953,
        LO = 0x4C4F,
        LT = 0x4C54,
        OB = 0x4F42,
        OF = 0x4F46,
        OW = 0x4F57,
        PN = 0x504E,
        SH = 0x5348,
        SL = 0x534C,
        SQ = 0x5351,
        SS = 0x5353,
        ST = 0x5354,
        TM = 0x544D,
        UI = 0x5549,
        UL = 0x554C,
        UN = 0x554E,
        US = 0x5553,
        UT = 0x5554,
        UK = 0x554B,
        RT = 0x5254
    }

    public class DicomVr
    {
        private DicomVr(){}

        /// <summary> 
        /// NULL element for VRs. Use as VR value for BuffferData Elements,
        /// Item (FFFE,E000), Item Delimitation Item (FFFE,E00D), and
        /// Sequence Delimitation Item (FFFE,E0DD).
        /// </summary>

        public const int NONE = 0x0000;
        public const int AE = 0x4145;
        public const int AS = 0x4153;
        public const int AT = 0x4154;
        public const int CS = 0x4353;
        public const int DA = 0x4441;
        public const int DS = 0x4453;
        public const int DT = 0x4454;
        public const int FL = 0x464C;
        public const int FD = 0x4644;
        public const int IS = 0x4953;
        public const int LO = 0x4C4F;
        public const int LT = 0x4C54;
        public const int OB = 0x4F42;
        public const int OF = 0x4F46;
        public const int OW = 0x4F57;
        public const int PN = 0x504E;
        public const int SH = 0x5348;
        public const int SL = 0x534C;
        public const int SQ = 0x5351;
        public const int SS = 0x5353;
        public const int ST = 0x5354;
        public const int TM = 0x544D;
        public const int UI = 0x5549;
        public const int UL = 0x554C;
        public const int UN = 0x554E;
        public const int US = 0x5553;
        public const int UT = 0x5554;
        public const int UK = 0x554B;
        public const int RT = 0x5254;

        
        //public static int ValueOf(string str)
        //{
        //    if ("NONE".Equals(str))
        //    {
        //        return (int)VR.NONE;
        //    }

        //    if (str.Length != 2)
        //    {
        //        throw new ArgumentException(str);
        //    }

        //    return ((str[0] & 0xff) << 8) | (str[1] & 0xff);
        //}

        
        //public static byte GetPadding(int vr)
        //{
        //    switch (vr)
        //    {
        //        case (int)VR.AE:
        //        case (int)VR.AS:
        //        case (int)VR.CS:
        //        case (int)VR.DA:
        //        case (int)VR.DS:
        //        case (int)VR.DT:
        //        case (int)VR.IS:
        //        case (int)VR.LO:
        //        case (int)VR.LT:
        //        case (int)VR.PN:
        //        case (int)VR.SH:
        //        case (int)VR.SL:
        //        case (int)VR.ST:
        //        case (int)VR.TM:
        //        case (int)VR.UT:
        //            return (byte)' ';

        //        default:
        //            return 0;
        //    }
        //}

        
        //public static bool IsEncodedStringValue(int vr)
        //{
        //    switch (vr)
        //    {
        //        case (int)VR.LO:
        //        case (int)VR.LT:
        //        case (int)VR.PN:
        //        case (int)VR.SH:
        //        case (int)VR.ST:
        //        case (int)VR.UT:
        //            return true;
        //        default:
        //            return false;
        //    }
        //}


        /// <summary>
        /// 获取vr的字符串显示
        /// </summary>
        /// <param name="vr"></param>
        /// <returns></returns>
        public static string ToString(int vr)
        {
            return vr == (int) VR.NONE ? "NONE" : new string(new[] {(char) (vr >> 8), (char) (vr & 0x00ff)});
        }

        /// <summary>
        /// These VRs have 2 bytes fixed length
        /// 判断vr的Length是否为16位
        /// </summary>
        /// <param name="vr"></param>
        /// <returns></returns>
        public static bool IsLengthField16Bit(int vr)
        {
            switch (vr)
            {
                case (int)VR.AE:
                case (int)VR.AS:
                case (int)VR.AT:
                case (int)VR.CS:
                case (int)VR.DA:
                case (int)VR.DS:
                case (int)VR.DT:
                case (int)VR.FL:
                case (int)VR.FD:
                case (int)VR.IS:
                case (int)VR.LO:
                case (int)VR.LT:
                case (int)VR.PN:
                case (int)VR.SH:
                case (int)VR.SL:
                case (int)VR.SS:
                case (int)VR.ST:
                case (int)VR.TM:
                case (int)VR.UI:
                case (int)VR.UL:
                case (int)VR.US:
                case (int)VR.UK:
                case (int)VR.RT:
                //case (int)VR.UN:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// These VRs are string values
        /// 判断vr是否为字符串值
        /// </summary>
        /// <param name="vr"></param>
        /// <returns></returns>
        public static bool IsStringValue(int vr)
        {
            switch (vr)
            {
                case (int)VR.AE:
                case (int)VR.AS:
                case (int)VR.CS:
                case (int)VR.DA:
                case (int)VR.DS:
                case (int)VR.DT:
                case (int)VR.IS:
                case (int)VR.LO:
                case (int)VR.LT:
                case (int)VR.PN:
                case (int)VR.SH:
                case (int)VR.ST:
                case (int)VR.TM:
                case (int)VR.UI:
                case (int)VR.UT:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Get the VR of this tag
        /// 根据tag值获取vr值
        /// </summary>
        /// <param name="tag">the tag</param>
        /// <returns></returns>
        public static int GetVR(uint tag)
        {
            if ((tag & 0x0000ffff) == 0)
            {
                return (int)VR.UL;
            }
            switch (tag & 0xffff0000)
            {
                case 0x00000000:
                    return VrOfCommand(tag);

                case 0x00020000:
                    return VrOfFileMetaInfo(tag);

                case 0x00040000:
                    return VrOfDicomDir(tag);

            }
            if ((tag & 0x00010000) != 0)
            {
                return (tag & 0x0000ff00) == 0 ? (int) VR.LO : (int) VR.UN;
            }
            return VrOfData(tag);
        }

        public static int VrOfCommand(uint tag)
        {
            switch (tag)
            {
                case DicomTag.MoveDestination:
                case DicomTag.MoveOriginatorAET:
                    return (int)VR.AE;

                case DicomTag.OffendingElement:
                case DicomTag.AttributeIdentifierList:
                    return (int)VR.AT;

                case DicomTag.WADOSocketClientUID:
                case DicomTag.ErrorComment:
                    return (int)VR.LO;

                case DicomTag.AffectedSOPClassUID:
                case DicomTag.RequestedSOPClassUID:
                case DicomTag.AffectedSOPInstanceUID:
                case DicomTag.RequestedSOPInstanceUID:
                case DicomTag.SourceFrameOfReferenceUID:
                    return (int)VR.UI;

                case DicomTag.CommandLengthToEndRetired:
                case DicomTag.CommandRecognitionCodeRetired:
                case DicomTag.InitiatorRetired:
                case DicomTag.ReceiverRetired:
                case DicomTag.FindLocationRetired:
                case DicomTag.NumberOfMatchesRetired:
                case DicomTag.ResponseSequenceNumberRetired:
                case DicomTag.DialogReceiverRetired:
                case DicomTag.TerminalTypeRetired:
                case DicomTag.MessageSetIDRetired:
                case DicomTag.EndMessageIDRetired:
                case DicomTag.DisplayFormatRetired:
                case DicomTag.PagePositionIDRetired:
                case DicomTag.TextFormatIDRetired:
                case DicomTag.NorRevRetired:
                case DicomTag.AddGrayScaleRetired:
                case DicomTag.BordersRetired:
                case DicomTag.CopiesRetired:
                case DicomTag.MagnificationTypeRetired:
                case DicomTag.EraseRetired:
                case DicomTag.PrintRetired:
                    return (int)VR.UN;

                case DicomTag.CommandField:
                case DicomTag.MessageID:
                case DicomTag.MessageIDToBeingRespondedTo:
                case DicomTag.Priority:
                case DicomTag.DataSetType:
                case DicomTag.Status:
                case DicomTag.ErrorID:
                case DicomTag.EventTypeID:
                case DicomTag.ActionTypeID:
                case DicomTag.NumberOfRemainingSubOperations:
                case DicomTag.NumberOfCompletedSubOperations:
                case DicomTag.NumberOfFailedSubOperations:
                case DicomTag.NumberOfWarningSubOperations:
                case DicomTag.MoveOriginatorMessageID:
                    return (int)VR.US;
                default:
                    return (int)VR.UN;
            }

            //throw new ArgumentException("Unrecognized Tag " + DicomTag.ToHexString(tag));
        }

        public static int VrOfFileMetaInfo(uint tag)
        {
            switch (tag)
            {
                case DicomTag.SourceApplicationEntityTitle:
                    return (int)VR.AE;

                case DicomTag.FileMetaInformationVersion:
                case DicomTag.PrivateInformation:
                    return (int)VR.OB;

                case DicomTag.ImplementationVersionName:
                    return (int)VR.SH;

                case DicomTag.MediaStorageSOPClassUID:
                case DicomTag.MediaStorageSOPInstanceUID:
                case DicomTag.TransferSyntaxUID:
                case DicomTag.ImplementationClassUID:
                case DicomTag.PrivateInformationCreatorUID:
                    return (int)VR.UI;

            }
            throw new ArgumentException("Unrecognized Tag 0x" + Convert.ToString(tag, 16));
        }

        public static int VrOfDicomDir(uint tag)
        {
            switch (tag)
            {
                case DicomTag.FileSetID:
                case DicomTag.FileSetDescriptorFileID:
                case DicomTag.SpecificCharacterSetOfFileSetDescriptorFile:
                case DicomTag.DirectoryRecordType:
                case DicomTag.RefFileID:
                    return (int)VR.CS;

                case DicomTag.DirectoryRecordSeq:
                    return (int)VR.SQ;

                case DicomTag.PrivateRecordUID:
                case DicomTag.RefSOPClassUIDInFile:
                case DicomTag.RefSOPInstanceUIDInFile:
                case DicomTag.RefSOPTransferSyntaxUIDInFile:
                    return (int)VR.UI;

                case DicomTag.OffsetOfFirstRootDirectoryRecord:
                case DicomTag.OffsetOfLastRootDirectoryRecord:
                case DicomTag.OffsetOfNextDirectoryRecord:
                case DicomTag.OffsetOfLowerLevelDirectoryEntity:
                case DicomTag.MRDRDirectoryRecordOffset:
                case DicomTag.NumberOfReferences:
                    return (int)VR.UL;

                case DicomTag.FileSetConsistencyFlag:
                case DicomTag.RecordInUseFlag:
                    return (int)VR.US;

            }
            throw new ArgumentException("Unrecognized Tag 0x" + Convert.ToString(tag, 16));
        }
        
        public static int VrOfData(uint tag)
        {
            switch (tag)
            {
                case DicomTag.RetrieveAET:
                case DicomTag.ScheduledStudyLocationAET:
                case DicomTag.ScheduledStationAET:
                case DicomTag.PerformedStationAET:
                case DicomTag.Originator:
                case DicomTag.DestinationAE:
                    return (int)VR.AE;

                case DicomTag.PatientAge:
                    return (int)VR.AS;

                case DicomTag.DimensionIndexPointer:
                case DicomTag.FunctionalGroupSequencePointer:
                case DicomTag.FrameIncrementPointer:
                case DicomTag.OverrideParameterPointer:
                    return (int)VR.AT;

                case DicomTag.SpecificCharacterSet:
                case DicomTag.ImageType:
                case DicomTag.NuclearMedicineSeriesTypeRetired:
                case DicomTag.QueryRetrieveLevel:
                case DicomTag.InstanceAvailability:
                case DicomTag.Modality:
                case DicomTag.ModalitiesInStudy:
                case DicomTag.ConversionType:
                case DicomTag.PresentationIntentType:
                case DicomTag.MappingResource:
                case DicomTag.CodeSetExtensionFlag:
                case DicomTag.ContextIdentifier:
                case DicomTag.LossyImageCompressionRetired:
                case DicomTag.TransducerPositionRetired:
                case DicomTag.TransducerOrientationRetired:
                case DicomTag.AnatomicStructureRetired:
                case DicomTag.FrameType:
                case DicomTag.PixelPresentation:
                case DicomTag.VolumeBasedCalculationTechnique:
                case DicomTag.ComplexImageComponent:
                case DicomTag.AcquisitionContrast:
                case DicomTag.PatientSex:
                case DicomTag.SmokingStatus:
                case DicomTag.BodyPartExamined:
                case DicomTag.ScanningSeq:
                case DicomTag.SeqVariant:
                case DicomTag.ScanOptions:
                case DicomTag.MRAcquisitionType:
                case DicomTag.AngioFlag:
                case DicomTag.TherapyType:
                case DicomTag.InterventionalStatus:
                case DicomTag.TherapyDescription:
                case DicomTag.AcquisitionTerminationCondition:
                case DicomTag.AcquisitionStartCondition:
                case DicomTag.ContrastBolusIngredient:
                case DicomTag.SynchronizationTrigger:
                case DicomTag.BeatRejectionFlag:
                case DicomTag.TableMotion:
                case DicomTag.TableType:
                case DicomTag.RotationDirection:
                case DicomTag.FieldOfViewShape:
                case DicomTag.RadiationSetting:
                case DicomTag.RectificationType:
                case DicomTag.RadiationMode:
                case DicomTag.Grid:
                case DicomTag.CollimatorType:
                case DicomTag.AnodeTargetMaterial:
                case DicomTag.WholeBodyTechnique:
                case DicomTag.PhaseEncodingDirection:
                case DicomTag.VariableFlipAngleFlag:
                case DicomTag.CassetteOrientation:
                case DicomTag.CassetteSize:
                case DicomTag.ColumnAngulation:
                case DicomTag.TomoType:
                case DicomTag.TomoClass:
                case DicomTag.PositionerMotion:
                case DicomTag.PositionerType:
                case DicomTag.ShutterShape:
                case DicomTag.CollimatorShape:
                case DicomTag.AcquisitionTimeSynchronized:
                case DicomTag.TimeDistributionProtocol:
                case DicomTag.PatientPosition:
                case DicomTag.ViewPosition:
                case DicomTag.TransducerType:
                case DicomTag.DetectorConditionsNominalFlag:
                case DicomTag.DetectorType:
                case DicomTag.DetectorConfiguration:
                case DicomTag.DetectorActiveShape:
                case DicomTag.FieldOfViewHorizontalFlip:
                case DicomTag.FilterMaterial:
                case DicomTag.ExposureControlMode:
                case DicomTag.ExposureStatus:
                case DicomTag.ContentQualification:
                case DicomTag.EchoPulseSeq:
                case DicomTag.InversionRecovery:
                case DicomTag.FlowCompensation:
                case DicomTag.MultipleSpinEcho:
                case DicomTag.MultiPlanarExcitation:
                case DicomTag.PhaseContrast:
                case DicomTag.TimeOfFlightContrast:
                case DicomTag.Spoiling:
                case DicomTag.SteadyStatePulseSeq:
                case DicomTag.EchoPlanarPulseSeq:
                case DicomTag.MagnetizationTransfer:
                case DicomTag.T2Preparation:
                case DicomTag.BloodSignalNulling:
                case DicomTag.SaturationRecovery:
                case DicomTag.SpectrallySelectedSuppression:
                case DicomTag.SpectrallySelectedExcitation:
                case DicomTag.SpatialPreSaturation:
                case DicomTag.Tagging:
                case DicomTag.OversamplingPhase:
                case DicomTag.GeometryOfKSpaceTraversal:
                case DicomTag.SegmentedKSpaceTraversal:
                case DicomTag.RectilinearPhaseEncodeReordering:
                case DicomTag.PartialFourierDirection:
                case DicomTag.GatingSynchronizationTechnique:
                case DicomTag.ReceiveCoilType:
                case DicomTag.QuadratureReceiveCoil:
                case DicomTag.MultiCoilElementUsed:
                case DicomTag.TransmitCoilType:
                case DicomTag.VolumeLocalizationTechnique:
                case DicomTag.DeCoupling:
                case DicomTag.DeCoupledNucleus:
                case DicomTag.DeCouplingMethod:
                case DicomTag.KSpaceFiltering:
                case DicomTag.TimeDomainFiltering:
                case DicomTag.BaselineCorrection:
                case DicomTag.DiffusionDirectionality:
                case DicomTag.ParallelAcquisition:
                case DicomTag.ParallelAcquisitionTechnique:
                case DicomTag.PartialFourier:
                case DicomTag.CardiacSignalSource:
                case DicomTag.CoverageOfKSpace:
                case DicomTag.ResonantNucleus:
                case DicomTag.FrequencyCorrection:
                case DicomTag.DiffusionAnisotropyType:
                case DicomTag.BulkMotionStatus:
                case DicomTag.CardiacBeatRejectionTechnique:
                case DicomTag.RespiratoryMotionCompensation:
                case DicomTag.RespiratorySignalSource:
                case DicomTag.BulkMotionCompensationTechnique:
                case DicomTag.BulkMotionSignal:
                case DicomTag.ApplicableSafetyStandardAgency:
                case DicomTag.OperatingModeType:
                case DicomTag.OperationMode:
                case DicomTag.SpecificAbsorptionRateDefInition:
                case DicomTag.GradientOutputType:
                case DicomTag.FlowCompensationDirection:
                case DicomTag.FirstOrderPhaseCorrection:
                case DicomTag.WaterReferencedPhaseCorrection:
                case DicomTag.MRSpectroscopyAcquisitionType:
                case DicomTag.RespiratoryMotionStatus:
                case DicomTag.CardiacMotionStatus:
                case DicomTag.PatientOrientation:
                case DicomTag.Laterality:
                case DicomTag.ImageLaterality:
                case DicomTag.ImageGeometryTypeRetired:
                case DicomTag.MaskingImageRetired:
                case DicomTag.FrameLaterality:
                case DicomTag.PhotometricInterpretation:
                case DicomTag.CorrectedImage:
                case DicomTag.CompressionCodeRetired:
                case DicomTag.QualityControlImage:
                case DicomTag.BurnedInAnnotation:
                case DicomTag.PixelIntensityRelationship:
                case DicomTag.RecommendedViewingMode:
                case DicomTag.ImplantPresent:
                case DicomTag.PartialView:
                case DicomTag.LossyImageCompression:
                case DicomTag.MaskOperation:
                case DicomTag.SignalDomain:
                case DicomTag.DataRepresentation:
                case DicomTag.SignalDomainRows:
                case DicomTag.StudyStatusID:
                case DicomTag.StudyPriorityID:
                case DicomTag.StudyComponentStatusID:
                case DicomTag.VisitStatusID:
                case DicomTag.WaveformOriginality:
                case DicomTag.ChannelStatus:
                case DicomTag.SPSStatus:
                case DicomTag.PPSStatus:
                case DicomTag.OrganExposed:
                case DicomTag.RelationshipType:
                case DicomTag.ValueType:
                case DicomTag.ContinuityOfContent:
                case DicomTag.TemporalRangeType:
                case DicomTag.CompletionFlag:
                case DicomTag.VerificationFlag:
                case DicomTag.TemplateIdentifier:
                case DicomTag.TemplateExtensionFlag:
                case DicomTag.CalibrationImage:
                case DicomTag.DeviceDiameterUnits:
                case DicomTag.TypeOfDetectorMotion:
                case DicomTag.SeriesType:
                case DicomTag.Units:
                case DicomTag.CountsSource:
                case DicomTag.ReprojectionMethod:
                case DicomTag.RandomsCorrectionMethod:
                case DicomTag.DecayCorrection:
                case DicomTag.SecondaryCountsType:
                case DicomTag.CountsIncluded:
                case DicomTag.DeadTimeCorrectionFlag:
                case DicomTag.GraphicLayer:
                case DicomTag.BoundingBoxAnnotationUnits:
                case DicomTag.AnchorPointAnnotationUnits:
                case DicomTag.GraphicAnnotationUnits:
                case DicomTag.BoundingBoxTextHorizontalJustification:
                case DicomTag.AnchorPointVisibility:
                case DicomTag.GraphicType:
                case DicomTag.GraphicFilled:
                case DicomTag.ImageHorizontalFlip:
                case DicomTag.PresentationLabel:
                case DicomTag.PresentationSizeMode:
                case DicomTag.SOPInstanceStatus:
                case DicomTag.PrintPriority:
                case DicomTag.MediumType:
                case DicomTag.FilmDestination:
                case DicomTag.ColorImagePrintingFlag:
                case DicomTag.CollationFlag:
                case DicomTag.AnnotationFlag:
                case DicomTag.ImageOverlayFlag:
                case DicomTag.PresentationLUTFlag:
                case DicomTag.ImageBoxPresentationLUTFlag:
                case DicomTag.AnnotationDisplayFormatID:
                case DicomTag.FilmOrientation:
                case DicomTag.FilmSizeID:
                case DicomTag.PrinterResolutionID:
                case DicomTag.DefaultPrinterResolutionID:
                case DicomTag.MagnificationType:
                case DicomTag.SmoothingType:
                case DicomTag.DefaultMagnificationType:
                case DicomTag.OtherMagnificationTypesAvailable:
                case DicomTag.DefaultSmoothingType:
                case DicomTag.OtherSmoothingTypesAvailable:
                case DicomTag.BorderDensity:
                case DicomTag.EmptyImageDensity:
                case DicomTag.Trim:
                case DicomTag.Polarity:
                case DicomTag.RequestedDecimateCropBehavior:
                case DicomTag.RequestedResolutionID:
                case DicomTag.RequestedImageSizeFlag:
                case DicomTag.DecimateCropResult:
                case DicomTag.OverlayMagnificationType:
                case DicomTag.OverlaySmoothingType:
                case DicomTag.OverlayOrImageMagnification:
                case DicomTag.OverlayForegroundDensity:
                case DicomTag.OverlayBackgroundDensity:
                case DicomTag.OverlayModeRetired:
                case DicomTag.ThresholdDensityRetired:
                case DicomTag.PresentationLUTShape:
                case DicomTag.ExecutionStatus:
                case DicomTag.ExecutionStatusInfo:
                case DicomTag.PrinterStatus:
                case DicomTag.PrinterStatusInfo:
                case DicomTag.QueueStatus:
                case DicomTag.ReportedValuesOrigin:
                case DicomTag.RTImagePlane:
                case DicomTag.DVHType:
                case DicomTag.DoseUnits:
                case DicomTag.DoseType:
                case DicomTag.DoseSummationType:
                case DicomTag.DVHVolumeUnits:
                case DicomTag.DVHROIContributionType:
                case DicomTag.RTROIRelationship:
                case DicomTag.ROIGenerationAlgorithm:
                case DicomTag.ContourGeometricType:
                case DicomTag.RTROIInterpretedType:
                case DicomTag.ROIPhysicalProperty:
                case DicomTag.FrameOfReferenceTransformationType:
                case DicomTag.MeasuredDoseType:
                case DicomTag.TreatmentTerminationStatus:
                case DicomTag.TreatmentVerificationStatus:
                case DicomTag.ApplicationSetupCheck:
                case DicomTag.CurrentTreatmentStatus:
                case DicomTag.FractionGroupType:
                case DicomTag.BeamStopperPosition:
                case DicomTag.TreatmentIntent:
                case DicomTag.RTPlanGeometry:
                case DicomTag.DoseReferenceStructureType:
                case DicomTag.NominalBeamEnergyUnit:
                case DicomTag.DoseReferenceType:
                case DicomTag.RTPlanRelationship:
                case DicomTag.PrimaryDosimeterUnit:
                case DicomTag.RTBeamLimitingDeviceType:
                case DicomTag.BeamType:
                case DicomTag.RadiationType:
                case DicomTag.TreatmentDeliveryType:
                case DicomTag.WedgeType:
                case DicomTag.CompensatorType:
                case DicomTag.BlockType:
                case DicomTag.BlockDivergence:
                case DicomTag.ApplicatorType:
                case DicomTag.WedgePosition:
                case DicomTag.GantryRotationDirection:
                case DicomTag.BeamLimitingDeviceRotationDirection:
                case DicomTag.PatientSupportRotationDirection:
                case DicomTag.TableTopEccentricRotationDirection:
                case DicomTag.FixationDeviceType:
                case DicomTag.ShieldingDeviceType:
                case DicomTag.SetupTechnique:
                case DicomTag.SetupDeviceType:
                case DicomTag.BrachyTreatmentTechnique:
                case DicomTag.BrachyTreatmentType:
                case DicomTag.SourceType:
                case DicomTag.ApplicationSetupType:
                case DicomTag.BrachyAccessoryDeviceType:
                case DicomTag.SourceMovementType:
                case DicomTag.SourceApplicatorType:
                case DicomTag.ApprovalStatus:
                case DicomTag.InterpretationTypeID:
                case DicomTag.InterpretationStatusID:
                case DicomTag.WaveformSampleInterpretation:
                case DicomTag.CertificateType:
                case DicomTag.CertifiedTimestampType:
                case DicomTag.ReasonfortheAttributeModification:
                case DicomTag.PresentationTickAlignment:
                case DicomTag.PresentationTickLabelAlignment:
                case DicomTag.HorizontalAlignment:
                case DicomTag.VerticalAlignment:
                case DicomTag.Underlined:
                case DicomTag.Bold:
                case DicomTag.Italic:
                case DicomTag.LineDashingStyle:
               
                    return (int)VR.CS;

                case DicomTag.InstanceCreationDate:
                case DicomTag.StudyDate:
                case DicomTag.SeriesDate:
                case DicomTag.AcquisitionDate:
                case DicomTag.ContentDate:
                case DicomTag.OverlayDate:
                case DicomTag.CurveDate:
                case DicomTag.PatientBirthDate:
                case DicomTag.LastMenstrualDate:
                case DicomTag.DateOfSecondaryCapture:
                case DicomTag.DateOfLastCalibration:
                case DicomTag.DateOfLastDetectorCalibration:
                case DicomTag.ModifiedImageDateRetired:
                case DicomTag.StudyVerifiedDate:
                case DicomTag.StudyReadDate:
                case DicomTag.ScheduledStudyStartDate:
                case DicomTag.ScheduledStudyStopDate:
                case DicomTag.StudyArrivalDate:
                case DicomTag.StudyCompletionDate:
                case DicomTag.ScheduledAdmissionDate:
                case DicomTag.ScheduledDischargeDate:
                case DicomTag.AdmittingDate:
                case DicomTag.DischargeDate:
                case DicomTag.SPSStartDate:
                case DicomTag.SPSEndDate:
                case DicomTag.PPSStartDate:
                case DicomTag.PPSEndDate:
                case DicomTag.IssueDateOfImagingServiceRequest:
                case DicomTag.Date:
                case DicomTag.PresentationCreationDate:
                case DicomTag.CreationDate:
                case DicomTag.StructureSetDate:
                case DicomTag.TreatmentControlPointDate:
                case DicomTag.FirstTreatmentDate:
                case DicomTag.MostRecentTreatmentDate:
                case DicomTag.SafePositionExitDate:
                case DicomTag.SafePositionReturnDate:
                case DicomTag.TreatmentDate:
                case DicomTag.RTPlanDate:
                case DicomTag.AirKermaRateReferenceDate:
                case DicomTag.ReviewDate:
                case DicomTag.InterpretationRecordedDate:
                case DicomTag.InterpretationTranscriptionDate:
                case DicomTag.InterpretationApprovalDate:
                    return (int)VR.DA;

                case DicomTag.EventElapsedTime:
                case DicomTag.PatientSize:
                case DicomTag.PatientWeight:
                case DicomTag.InterventionDrugDose:
                case DicomTag.EnergyWindowCenterlineRetired:
                case DicomTag.EnergyWindowTotalWidthRetired:
                case DicomTag.SliceThickness:
                case DicomTag.KVP:
                case DicomTag.EffectiveSeriesDuration:
                case DicomTag.RepetitionTime:
                case DicomTag.EchoTime:
                case DicomTag.InversionTime:
                case DicomTag.NumberOfAverages:
                case DicomTag.ImagingFrequency:
                case DicomTag.MagneticFieldStrength:
                case DicomTag.SpacingBetweenSlices:
                case DicomTag.DataCollectionDiameter:
                case DicomTag.PercentSampling:
                case DicomTag.PercentPhaseFieldOfView:
                case DicomTag.PixelBandwidth:
                case DicomTag.ContrastBolusVolume:
                case DicomTag.ContrastBolusTotalDose:
                case DicomTag.ContrastFlowRate:
                case DicomTag.ContrastFlowDuration:
                case DicomTag.ContrastBolusIngredientConcentration:
                case DicomTag.SpatialResolution:
                case DicomTag.TriggerTime:
                case DicomTag.FrameTime:
                case DicomTag.FrameTimeVector:
                case DicomTag.FrameDelay:
                case DicomTag.ImageTriggerDelay:
                case DicomTag.MultiplexGroupTimeOffset:
                case DicomTag.TriggerTimeOffset:
                case DicomTag.RadiopharmaceuticalVolume:
                case DicomTag.RadionuclideTotalDose:
                case DicomTag.RadionuclideHalfLife:
                case DicomTag.RadionuclidePositronFraction:
                case DicomTag.RadiopharmaceuticalSpecificActivity:
                case DicomTag.ReconstructionDiameter:
                case DicomTag.DistanceSourceToDetector:
                case DicomTag.DistanceSourceToPatient:
                case DicomTag.EstimatedRadiographicMagnificationFactor:
                case DicomTag.GantryDetectorTilt:
                case DicomTag.GantryDetectorSlew:
                case DicomTag.TableHeight:
                case DicomTag.TableTraverse:
                case DicomTag.TableVerticalIncrement:
                case DicomTag.TableLateralIncrement:
                case DicomTag.TableLongitudinalIncrement:
                case DicomTag.TableAngle:
                case DicomTag.AngularPosition:
                case DicomTag.RadialPosition:
                case DicomTag.ScanArc:
                case DicomTag.AngularStep:
                case DicomTag.CenterOfRotationOffset:
                case DicomTag.RotationOffsetRetired:
                case DicomTag.AveragePulseWidth:
                case DicomTag.ImageAreaDoseProduct:
                case DicomTag.IntensifierSize:
                case DicomTag.ImagerPixelSpacing:
                case DicomTag.XFocusCenter:
                case DicomTag.YFocusCenter:
                case DicomTag.FocalSpot:
                case DicomTag.BodyPartThickness:
                case DicomTag.CompressionForce:
                case DicomTag.ScanVelocity:
                case DicomTag.FlipAngle:
                case DicomTag.SAR:
                case DicomTag.dBDt:
                case DicomTag.TomoLayerHeight:
                case DicomTag.TomoAngle:
                case DicomTag.TomoTime:
                case DicomTag.PositionerPrimaryAngle:
                case DicomTag.PositionerSecondaryAngle:
                case DicomTag.PositionerPrimaryAngleIncrement:
                case DicomTag.PositionerSecondaryAngleIncrement:
                case DicomTag.DetectorPrimaryAngle:
                case DicomTag.DetectorSecondaryAngle:
                case DicomTag.FocusDepth:
                case DicomTag.MechanicalIndex:
                case DicomTag.ThermalIndex:
                case DicomTag.CranialThermalIndex:
                case DicomTag.SoftTissueThermalIndex:
                case DicomTag.SoftTissueFocusThermalIndex:
                case DicomTag.SoftTissueSurfaceThermalIndex:
                case DicomTag.ImageTransformationMatrix:
                case DicomTag.ImageTranslationVector:
                case DicomTag.Sensitivity:
                case DicomTag.DetectorTemperature:
                case DicomTag.DetectorTimeSinceLastExposure:
                case DicomTag.DetectorActiveTime:
                case DicomTag.DetectorActivationOffsetFromExposure:
                case DicomTag.DetectorBinning:
                case DicomTag.DetectorElementPhysicalSize:
                case DicomTag.DetectorElementSpacing:
                case DicomTag.DetectorActiveDimension:
                case DicomTag.DetectorActiveOrigin:
                case DicomTag.FieldOfViewOrigin:
                case DicomTag.FieldOfViewRotation:
                case DicomTag.GridThickness:
                case DicomTag.GridPitch:
                case DicomTag.GridPeriod:
                case DicomTag.GridFocalDistance:
                case DicomTag.FilterThicknessMinimum:
                case DicomTag.FilterThicknessMaximum:
                case DicomTag.PhototimerSetting:
                case DicomTag.ExposureTimeInuS:
                case DicomTag.XRayTubeCurrentInuA:
                case DicomTag.ImagePositionRetired:
                case DicomTag.ImagePosition:
                case DicomTag.ImageOrientationRetired:
                case DicomTag.ImageOrientation:
                case DicomTag.TemporalResolution:
                case DicomTag.SliceLocation:
                case DicomTag.PixelSpacing:
                case DicomTag.ZoomFactor:
                case DicomTag.ZoomCenter:
                case DicomTag.WindowCenter:
                case DicomTag.WindowWidth:
                case DicomTag.RescaleIntercept:
                case DicomTag.RescaleSlope:
                case DicomTag.LossyImageCompressionRatio:
                case DicomTag.SamplingFrequency:
                case DicomTag.ChannelSensitivity:
                case DicomTag.ChannelSensitivityCorrectionFactor:
                case DicomTag.ChannelBaseline:
                case DicomTag.ChannelTimeSkew:
                case DicomTag.ChannelSampleSkew:
                case DicomTag.ChannelOffset:
                case DicomTag.FilterLowFrequency:
                case DicomTag.FilterHighFrequency:
                case DicomTag.NotchFilterFrequency:
                case DicomTag.NotchFilterBandwidth:
                case DicomTag.Quantity:
                case DicomTag.DistanceSourceToEntrance:
                case DicomTag.DistanceSourceToSupport:
                case DicomTag.XRayOutput:
                case DicomTag.HalfValueLayer:
                case DicomTag.OrganDose:
                case DicomTag.XOffsetInSlideCoordinateSystem:
                case DicomTag.YOffsetInSlideCoordinateSystem:
                case DicomTag.ZOffsetInSlideCoordinateSystem:
                case DicomTag.EntranceDoseInmGy:
                case DicomTag.RefTimeOffsets:
                case DicomTag.NumericValue:
                case DicomTag.DeviceLength:
                case DicomTag.DeviceDiameter:
                case DicomTag.DeviceVolume:
                case DicomTag.InterMarkerDistance:
                case DicomTag.EnergyWindowLowerLimit:
                case DicomTag.EnergyWindowUpperLimit:
                case DicomTag.TimeSlotTime:
                case DicomTag.StartAngle:
                case DicomTag.AxialAcceptance:
                case DicomTag.DetectorElementSize:
                case DicomTag.CoincidenceWindowWidth:
                case DicomTag.FrameReferenceTime:
                case DicomTag.SliceSensitivityFactor:
                case DicomTag.DecayFactor:
                case DicomTag.DoseCalibrationFactor:
                case DicomTag.ScatterFractionFactor:
                case DicomTag.DeadTimeFactor:
                case DicomTag.PresentationPixelSpacing:
                case DicomTag.PrinterPixelSpacing:
                case DicomTag.RequestedImageSize:
                case DicomTag.XRayImageReceptorTranslation:
                case DicomTag.XRayImageReceptorAngle:
                case DicomTag.RTImageOrientation:
                case DicomTag.ImagePlanePixelSpacing:
                case DicomTag.RTImagePosition:
                case DicomTag.RadiationMachineSAD:
                case DicomTag.RadiationMachineSSD:
                case DicomTag.RTImageSID:
                case DicomTag.SourceToReferenceObjectDistance:
                case DicomTag.MetersetExposure:
                case DicomTag.NormalizationPoint:
                case DicomTag.GridFrameOffsetVector:
                case DicomTag.DoseGridScaling:
                case DicomTag.DoseValue:
                case DicomTag.DVHNormalizationPoint:
                case DicomTag.DVHNormalizationDoseValue:
                case DicomTag.DVHDoseScaling:
                case DicomTag.DVHData:
                case DicomTag.DVHMinimumDose:
                case DicomTag.DVHMaximumDose:
                case DicomTag.DVHMeanDose:
                case DicomTag.ROIVolume:
                case DicomTag.ContourSlabThickness:
                case DicomTag.ContourOffsetVector:
                case DicomTag.ContourData:
                case DicomTag.ROIPhysicalPropertyValue:
                case DicomTag.FrameOfReferenceTransformationMatrix:
                case DicomTag.MeasuredDoseValue:
                case DicomTag.SpecifiedPrimaryMeterset:
                case DicomTag.SpecifiedSecondaryMeterset:
                case DicomTag.DeliveredPrimaryMeterset:
                case DicomTag.DeliveredSecondaryMeterset:
                case DicomTag.SpecifiedTreatmentTime:
                case DicomTag.DeliveredTreatmentTime:
                case DicomTag.SpecifiedMeterset:
                case DicomTag.DeliveredMeterset:
                case DicomTag.DoseRateDelivered:
                case DicomTag.CumulativeDoseToDoseReference:
                case DicomTag.CalculatedDoseReferenceDoseValue:
                case DicomTag.StartMeterset:
                case DicomTag.EndMeterset:
                case DicomTag.SpecifiedChannelTotalTime:
                case DicomTag.DeliveredChannelTotalTime:
                case DicomTag.SpecifiedPulseRepetitionInterval:
                case DicomTag.DeliveredPulseRepetitionInterval:
                case DicomTag.DoseReferencePointCoordinates:
                case DicomTag.NominalPriorDose:
                case DicomTag.ConstraintWeight:
                case DicomTag.DeliveryWarningDose:
                case DicomTag.DeliveryMaximumDose:
                case DicomTag.TargetMinimumDose:
                case DicomTag.TargetPrescriptionDose:
                case DicomTag.TargetMaximumDose:
                case DicomTag.TargetUnderdoseVolumeFraction:
                case DicomTag.OrganAtRiskFullVolumeDose:
                case DicomTag.OrganAtRiskLimitDose:
                case DicomTag.OrganAtRiskMaximumDose:
                case DicomTag.OrganAtRiskOverdoseVolumeFraction:
                case DicomTag.GantryAngleTolerance:
                case DicomTag.BeamLimitingDeviceAngleTolerance:
                case DicomTag.BeamLimitingDevicePositionTolerance:
                case DicomTag.PatientSupportAngleTolerance:
                case DicomTag.TableTopEccentricAngleTolerance:
                case DicomTag.TableTopVerticalPositionTolerance:
                case DicomTag.TableTopLongitudinalPositionTolerance:
                case DicomTag.TableTopLateralPositionTolerance:
                case DicomTag.BeamDoseSpecificationPoint:
                case DicomTag.BeamDose:
                case DicomTag.BeamMeterset:
                case DicomTag.BrachyApplicationSetupDoseSpecificationPoint:
                case DicomTag.BrachyApplicationSetupDose:
                case DicomTag.SourceAxisDistance:
                case DicomTag.SourceToBeamLimitingDeviceDistance:
                case DicomTag.LeafPositionBoundaries:
                case DicomTag.WedgeFactor:
                case DicomTag.WedgeOrientation:
                case DicomTag.SourceToWedgeTrayDistance:
                case DicomTag.TotalCompensatorTrayFactor:
                case DicomTag.SourceToCompensatorTrayDistance:
                case DicomTag.CompensatorPixelSpacing:
                case DicomTag.CompensatorPosition:
                case DicomTag.CompensatorTransmissionData:
                case DicomTag.CompensatorThicknessData:
                case DicomTag.TotalBlockTrayFactor:
                case DicomTag.SourceToBlockTrayDistance:
                case DicomTag.BlockThickness:
                case DicomTag.BlockTransmission:
                case DicomTag.BlockData:
                case DicomTag.CumulativeDoseReferenceCoefficient:
                case DicomTag.FinalCumulativeMetersetWeight:
                case DicomTag.NominalBeamEnergy:
                case DicomTag.DoseRateSet:
                case DicomTag.LeafJawPositions:
                case DicomTag.GantryAngle:
                case DicomTag.BeamLimitingDeviceAngle:
                case DicomTag.PatientSupportAngle:
                case DicomTag.TableTopEccentricAxisDistance:
                case DicomTag.TableTopEccentricAngle:
                case DicomTag.TableTopVerticalPosition:
                case DicomTag.TableTopLongitudinalPosition:
                case DicomTag.TableTopLateralPosition:
                case DicomTag.IsocenterPosition:
                case DicomTag.SurfaceEntryPoint:
                case DicomTag.SourceToSurfaceDistance:
                case DicomTag.CumulativeMetersetWeight:
                case DicomTag.SetupDeviceParameter:
                case DicomTag.TableTopVerticalSetupDisplacement:
                case DicomTag.TableTopLongitudinalSetupDisplacement:
                case DicomTag.TableTopLateralSetupDisplacement:
                case DicomTag.ActiveSourceDiameter:
                case DicomTag.ActiveSourceLength:
                case DicomTag.SourceEncapsulationNominalThickness:
                case DicomTag.SourceEncapsulationNominalTransmission:
                case DicomTag.SourceIsotopeHalfLife:
                case DicomTag.ReferenceAirKermaRate:
                case DicomTag.TotalReferenceAirKerma:
                case DicomTag.BrachyAccessoryDeviceNominalThickness:
                case DicomTag.BrachyAccessoryDeviceNominalTransmission:
                case DicomTag.ChannelLength:
                case DicomTag.ChannelTotalTime:
                case DicomTag.PulseRepetitionInterval:
                case DicomTag.SourceApplicatorLength:
                case DicomTag.SourceApplicatorWallNominalThickness:
                case DicomTag.SourceApplicatorWallNominalTransmission:
                case DicomTag.SourceApplicatorStepSize:
                case DicomTag.TransferTubeLength:
                case DicomTag.ChannelShieldNominalThickness:
                case DicomTag.ChannelShieldNominalTransmission:
                case DicomTag.FinalCumulativeTimeWeight:
                case DicomTag.ControlPointRelativePosition:
                case DicomTag.ControlPoint3DPosition:
                case DicomTag.CumulativeTimeWeight:
                case DicomTag.StartCumulativeMetersetWeight:
                case DicomTag.EndCumulativeMetersetWeight:
                    return (int)VR.DS;

                case DicomTag.AcquisitionDatetime:
                case DicomTag.ContextGroupVersion:
                case DicomTag.ContextGroupLocalVersion:
                case DicomTag.FrameAcquisitionDatetime:
                case DicomTag.FrameReferenceDatetime:
                case DicomTag.VerificationDateTime:
                case DicomTag.ObservationDateTime:
                case DicomTag.DateTime:
                case DicomTag.RefDatetime:
                case DicomTag.TemplateVersion:
                case DicomTag.TemplateLocalVersion:
                case DicomTag.SOPAuthorizationDateAndTime:
                case DicomTag.ContributionDateTime:
                case DicomTag.DigitalSignatureDateTime:
                case DicomTag.AttributeModificationDatetime:
                    return (int)VR.DT;

                case DicomTag.ReferencePixelPhysicalValueX:
                case DicomTag.ReferencePixelPhysicalValueY:
                case DicomTag.PhysicalDeltaX:
                case DicomTag.PhysicalDeltaY:
                case DicomTag.DopplerCorrectionAngle:
                case DicomTag.SteeringAngle:
                case DicomTag.TableOfYBreakPoints:
                case DicomTag.TagAngleFirstAxis:
                case DicomTag.TagSpacingFirstDimension:
                case DicomTag.TagThickness:
                case DicomTag.SpectralWidth:
                case DicomTag.ChemicalShiftReference:
                case DicomTag.DeCouplingFrequency:
                case DicomTag.DeCouplingChemicalShiftReference:
                case DicomTag.CardiacRRIntervalSpecified:
                case DicomTag.AcquisitionDuration:
                case DicomTag.InversionTimes:
                case DicomTag.EffectiveEchoTime:
                case DicomTag.DiffusionBValue:
                case DicomTag.DiffusionGradientOrientation:
                case DicomTag.VelocityEncodingDirection:
                case DicomTag.VelocityEncodingMinimumValue:
                case DicomTag.ParallelReductionFactorInPlane:
                case DicomTag.TransmitterFrequency:
                case DicomTag.SlabThickness:
                case DicomTag.SlabOrientation:
                case DicomTag.MidSlabPosition:
                case DicomTag.ParallelReductionFactorOutOfPlane:
                case DicomTag.ParallelReductionFactorSecondInPlane:
                case DicomTag.SpecificAbsorptionRateValue:
                case DicomTag.GradientOutput:
                case DicomTag.TaggingDelay:
                case DicomTag.ChemicalShiftsMinimumIntegrationLimit:
                case DicomTag.ChemicalShiftsMaximumIntegrationLimit:
                case DicomTag.VelocityEncodingMaximumValue:
                case DicomTag.FrameAcquisitionDuration:
                case DicomTag.TriggerDelayTime:
                case DicomTag.RealWorldValueLUTData:
                case DicomTag.RealWorldValueIntercept:
                case DicomTag.RealWorldValueSlope:
                case DicomTag.GridResolution:
                case DicomTag.PresentationRotationAngle:
                
                    return (int)VR.FD;

                case DicomTag.TableOfParameterValues:
                case DicomTag.MaskSubPixelShift:
                case DicomTag.BoundingBoxTopLeftHandCorner:
                case DicomTag.BoundingBoxBottomRightHandCorner:
                case DicomTag.AnchorPoint:
                case DicomTag.GraphicData:
                case DicomTag.PresentationPixelMagnificationRatio:
                case DicomTag.PresentationRotationPoint:
                case DicomTag.ShadowOffsetX:
                case DicomTag.ShadowOffsetY:
                case DicomTag.PatternOnOpacity:
                case DicomTag.PatternOffOpacity:
                case DicomTag.LineThickness:
                case DicomTag.ShadowOpacity:
                    return (int)VR.FL;

                case DicomTag.RefFrameNumber:
                case DicomTag.StageNumber:
                case DicomTag.NumberOfStages:
                case DicomTag.ViewNumber:
                case DicomTag.NumberOfEventTimers:
                case DicomTag.NumberOfViewsInStage:
                case DicomTag.StartTrim:
                case DicomTag.StopTrim:
                case DicomTag.RecommendedDisplayFrameRate:
                case DicomTag.CineRate:
                case DicomTag.CountsAccumulated:
                case DicomTag.AcquisitionStartConditionData:
                case DicomTag.AcquisitionTerminationConditionData:
                case DicomTag.EchoNumber:
                case DicomTag.NumberOfPhaseEncodingSteps:
                case DicomTag.EchoTrainLength:
                case DicomTag.SyringeCounts:
                case DicomTag.NominalInterval:
                case DicomTag.LowRRValue:
                case DicomTag.HighRRValue:
                case DicomTag.IntervalsAcquired:
                case DicomTag.IntervalsRejected:
                case DicomTag.SkipBeats:
                case DicomTag.HeartRate:
                case DicomTag.CardiacNumberOfImages:
                case DicomTag.TriggerWindow:
                case DicomTag.FieldOfViewDimension:
                case DicomTag.ExposureTime:
                case DicomTag.XRayTubeCurrent:
                case DicomTag.Exposure:
                case DicomTag.ExposureInuAs:
                case DicomTag.GeneratorPower:
                case DicomTag.FocalDistance:
                case DicomTag.ActualFrameDuration:
                case DicomTag.CountRate:
                case DicomTag.ScanLength:
                case DicomTag.RelativeXRayExposure:
                case DicomTag.NumberofTomosynthesisSourceImages:
                case DicomTag.ShutterLeftVerticalEdge:
                case DicomTag.ShutterRightVerticalEdge:
                case DicomTag.ShutterUpperHorizontalEdge:
                case DicomTag.ShutterLowerHorizontalEdge:
                case DicomTag.CenterOfCircularShutter:
                case DicomTag.RadiusOfCircularShutter:
                case DicomTag.VerticesOfPolygonalShutter:
                case DicomTag.CollimatorLeftVerticalEdge:
                case DicomTag.CollimatorRightVerticalEdge:
                case DicomTag.CollimatorUpperHorizontalEdge:
                case DicomTag.CollimatorLowerHorizontalEdge:
                case DicomTag.CenterOfCircularCollimator:
                case DicomTag.RadiusOfCircularCollimator:
                case DicomTag.VerticesOfPolygonalCollimator:
                case DicomTag.DepthOfScanField:
                case DicomTag.ExposuresOnDetectorSinceLastCalibration:
                case DicomTag.ExposuresOnDetectorSinceManufactured:
                case DicomTag.GridAspectRatio:
                case DicomTag.SeriesNumber:
                case DicomTag.AcquisitionNumber:
                case DicomTag.InstanceNumber:
                case DicomTag.IsotopeNumberRetired:
                case DicomTag.PhaseNumberRetired:
                case DicomTag.IntervalNumberRetired:
                case DicomTag.TimeSlotNumberRetired:
                case DicomTag.AngleNumberRetired:
                case DicomTag.ItemNumber:
                case DicomTag.OverlayNumber:
                case DicomTag.CurveNumber:
                case DicomTag.LUTNumber:
                case DicomTag.TemporalPositionIdentifier:
                case DicomTag.NumberOfTemporalPositions:
                case DicomTag.SeriesInStudy:
                case DicomTag.AcquisitionsInSeriesRetired:
                case DicomTag.ImagesInAcquisition:
                case DicomTag.AcquisitionsInStudy:
                case DicomTag.OtherStudyNumbers:
                case DicomTag.NumberOfPatientRelatedStudies:
                case DicomTag.NumberOfPatientRelatedSeries:
                case DicomTag.NumberOfPatientRelatedInstances:
                case DicomTag.NumberOfStudyRelatedSeries:
                case DicomTag.NumberOfStudyRelatedInstances:
                case DicomTag.NumberOfSeriesRelatedInstances:
                case DicomTag.NumberOfFrames:
                case DicomTag.PixelAspectRatio:
                case DicomTag.WaveformChannelNumber:
                case DicomTag.ResidualSyringeCounts:
                case DicomTag.PhaseDelay:
                case DicomTag.PauseBetweenFrames:
                case DicomTag.TriggerVector:
                case DicomTag.AxialMash:
                case DicomTag.TransverseMash:
                case DicomTag.PrimaryCountsAccumulated:
                case DicomTag.SecondaryCountsAccumulated:
                case DicomTag.GraphicLayerOrder:
                case DicomTag.PresentationPixelAspectRatio:
                case DicomTag.NumberOfCopies:
                case DicomTag.MemoryAllocation:
                case DicomTag.MaximumMemoryAllocation:
                case DicomTag.MaximumCollatedFilms:
                case DicomTag.NumberOfFilms:
                case DicomTag.FractionNumber:
                case DicomTag.DVHNumberOfBins:
                case DicomTag.ROINumber:
                case DicomTag.ROIDisplayColor:
                case DicomTag.NumberOfContourPoints:
                case DicomTag.ContourNumber:
                case DicomTag.AttachedContours:
                case DicomTag.ObservationNumber:
                case DicomTag.RefROINumber:
                case DicomTag.CurrentFractionNumber:
                case DicomTag.NumberOfFractionsDelivered:
                case DicomTag.MeasuredDoseReferenceNumber:
                case DicomTag.CalculatedDoseReferenceNumber:
                case DicomTag.RefMeasuredDoseReferenceNumber:
                case DicomTag.RefCalculatedDoseReferenceNumber:
                case DicomTag.RefBrachyAccessoryDeviceNumber:
                case DicomTag.SpecifiedNumberOfPulses:
                case DicomTag.DeliveredNumberOfPulses:
                case DicomTag.RefSourceApplicatorNumber:
                case DicomTag.RefChannelShieldNumber:
                case DicomTag.RefFractionNumber:
                case DicomTag.DoseReferenceNumber:
                case DicomTag.ToleranceTableNumber:
                case DicomTag.FractionGroupNumber:
                case DicomTag.NumberOfFractionsPlanned:
                case DicomTag.NumberOfFractionsPerDay:
                case DicomTag.RepeatFractionCycleLength:
                case DicomTag.NumberOfBeams:
                case DicomTag.NumberOfBrachyApplicationSetups:
                case DicomTag.NumberOfLeafJawPairs:
                case DicomTag.BeamNumber:
                case DicomTag.ReferenceImageNumber:
                case DicomTag.NumberOfWedges:
                case DicomTag.WedgeNumber:
                case DicomTag.WedgeAngle:
                case DicomTag.NumberOfCompensators:
                case DicomTag.CompensatorNumber:
                case DicomTag.CompensatorRows:
                case DicomTag.CompensatorColumns:
                case DicomTag.NumberOfBoli:
                case DicomTag.NumberOfBlocks:
                case DicomTag.BlockNumber:
                case DicomTag.BlockNumberOfPoints:
                case DicomTag.NumberOfControlPoints:
                case DicomTag.ControlPointIndex:
                case DicomTag.PatientSetupNumber:
                case DicomTag.SourceNumber:
                case DicomTag.ApplicationSetupNumber:
                case DicomTag.TemplateNumber:
                case DicomTag.BrachyAccessoryDeviceNumber:
                case DicomTag.ChannelNumber:
                case DicomTag.NumberOfPulses:
                case DicomTag.SourceApplicatorNumber:
                case DicomTag.TransferTubeNumber:
                case DicomTag.ChannelShieldNumber:
                case DicomTag.RefBeamNumber:
                case DicomTag.RefReferenceImageNumber:
                case DicomTag.RefBrachyApplicationSetupNumber:
                case DicomTag.RefSourceNumber:
                case DicomTag.RefFractionGroupNumber:
                case DicomTag.RefDoseReferenceNumber:
                case DicomTag.RefPatientSetupNumber:
                case DicomTag.RefToleranceTableNumber:
                case DicomTag.RefWedgeNumber:
                case DicomTag.RefCompensatorNumber:
                case DicomTag.RefBlockNumber:
                case DicomTag.RefControlPointIndex:
                    return (int)VR.IS;

                case DicomTag.Manufacturer:
                case DicomTag.InstitutionName:
                case DicomTag.CodeMeaning:
                case DicomTag.StudyDescription:
                case DicomTag.SeriesDescription:
                case DicomTag.InstitutionalDepartmentName:
                case DicomTag.AdmittingDiagnosisDescription:
                case DicomTag.ManufacturerModelName:
                case DicomTag.EventTimerName:
                case DicomTag.PatientID:
                case DicomTag.IssuerOfPatientID:
                case DicomTag.OtherPatientIDs:
                case DicomTag.PatientAddress:
                case DicomTag.InsurancePlanIdentificationRetired:
                case DicomTag.MilitaryRank:
                case DicomTag.BranchOfService:
                case DicomTag.MedicalRecordLocator:
                case DicomTag.MedicalAlerts:
                case DicomTag.ContrastAllergies:
                case DicomTag.CountryOfResidence:
                case DicomTag.RegionOfResidence:
                case DicomTag.PatientReligiousPreference:
                case DicomTag.ContrastBolusAgent:
                case DicomTag.RadionuclideRetired:
                case DicomTag.Radiopharmaceutical:
                case DicomTag.InterventionDrugName:
                case DicomTag.DeviceSerialNumber:
                case DicomTag.PlateID:
                case DicomTag.SecondaryCaptureDeviceID:
                case DicomTag.HardcopyCreationDeviceID:
                case DicomTag.SecondaryCaptureDeviceManufacturer:
                case DicomTag.HardcopyDeviceManufacturer:
                case DicomTag.SecondaryCaptureDeviceManufacturerModelName:
                case DicomTag.SecondaryCaptureDeviceSoftwareVersion:
                case DicomTag.HardcopyDeviceSoftwareVersion:
                case DicomTag.HardcopyDeviceManfuacturerModelName:
                case DicomTag.SoftwareVersion:
                case DicomTag.DigitalImageFormatAcquired:
                case DicomTag.ProtocolName:
                case DicomTag.ContrastBolusRoute:
                case DicomTag.TriggerSourceOrType:
                case DicomTag.FramingType:
                case DicomTag.RadiopharmaceuticalRoute:
                case DicomTag.PVCRejection:
                case DicomTag.TypeOfFilters:
                case DicomTag.PhosphorType:
                case DicomTag.AcquisitionDeviceProcessingDescription:
                case DicomTag.AcquisitionDeviceProcessingCode:
                case DicomTag.TransducerData:
                case DicomTag.ProcessingFunction:
                case DicomTag.PostprocessingFunction:
                case DicomTag.ReceiveCoilManufacturerName:
                case DicomTag.MultiCoilConfiguration:
                case DicomTag.TransmitCoilManufacturerName:
                case DicomTag.ApplicableSafetyStandardVersion:
                case DicomTag.PositionReferenceIndicator:
                case DicomTag.ModifyingDeviceManufacturerRetired:
                case DicomTag.ModifiedImageDescriptionRetired:
                case DicomTag.OriginalImageIdentificationRetired:
                case DicomTag.OriginalImageIdentificationNomenclatureRetired:
                case DicomTag.DimensionIndexPrivateCreator:
                case DicomTag.FunctionalGroupPrivateCreator:
                case DicomTag.RescaleType:
                case DicomTag.WindowCenterWidthExplanation:
                case DicomTag.LUTExplanation:
                case DicomTag.ModalityLUTType:
                case DicomTag.FrameOfInterestDescription:
                case DicomTag.StudyIDIssuer:
                case DicomTag.ScheduledStudyLocation:
                case DicomTag.ReasonforStudy:
                case DicomTag.RequestingService:
                case DicomTag.RequestedProcedureDescription:
                case DicomTag.RequestedContrastAgent:
                case DicomTag.AdmissionID:
                case DicomTag.IssuerOfAdmissionID:
                case DicomTag.RouteOfAdmissions:
                case DicomTag.ScheduledPatientInstitutionResidence:
                case DicomTag.DischargeDiagnosisDescription:
                case DicomTag.SpecialNeeds:
                case DicomTag.CurrentPatientLocation:
                case DicomTag.PatientInstitutionResidence:
                case DicomTag.PatientState:
                case DicomTag.ChannelDerivationDescription:
                case DicomTag.SPSDescription:
                case DicomTag.PreMedication:
                case DicomTag.PPSDescription:
                case DicomTag.PerformedProcedureTypeDescription:
                case DicomTag.SpecimenAccessionNumber:
                case DicomTag.SpecimenIdentifier:
                case DicomTag.SlideIdentifier:
                case DicomTag.ReasonForTheRequestedProcedure:
                case DicomTag.PatientTransportArrangements:
                case DicomTag.RequestedProcedureLocation:
                case DicomTag.ConfidentialityCode:
                case DicomTag.ReasonForTheImagingServiceRequest:
                case DicomTag.PlacerOrderNumber:
                case DicomTag.FillerOrderNumber:
                case DicomTag.ConfidentialityPatientData:
                case DicomTag.VerifyingOrganization:
                case DicomTag.CompletionFlagDescription:
                case DicomTag.DeviceDescription:
                case DicomTag.AttenuationCorrectionMethod:
                case DicomTag.ReconstructionMethod:
                case DicomTag.DetectorLinesOfResponseUsed:
                case DicomTag.ScatterCorrectionMethod:
                case DicomTag.HistogramExplanation:
                case DicomTag.GraphicLayerDescription:
                case DicomTag.PresentationDescription:
                case DicomTag.TopicTitle:
                case DicomTag.TopicAuthor:
                case DicomTag.TopicKeyWords:
                case DicomTag.AuthorizationEquipmentCertificationNumber:
                case DicomTag.FilmSessionLabel:
                case DicomTag.TextString:
                case DicomTag.PrinterName:
                case DicomTag.RTImageName:
                case DicomTag.DoseComment:
                case DicomTag.StructureSetName:
                case DicomTag.ROIName:
                case DicomTag.ROIGenerationDescription:
                case DicomTag.FrameOfReferenceTransformationComment:
                case DicomTag.SourceSerialNumber:
                case DicomTag.RTPlanName:
                case DicomTag.TreatmentProtocols:
                case DicomTag.TreatmentSites:
                case DicomTag.DoseReferenceDescription:
                case DicomTag.BeamName:
                case DicomTag.ImagingDeviceSpecificAcquisitionParameters:
                case DicomTag.BlockName:
                case DicomTag.ApplicatorDescription:
                case DicomTag.PatientAdditionalPosition:
                case DicomTag.SourceManufacturer:
                case DicomTag.SourceIsotopeName:
                case DicomTag.ApplicationSetupName:
                case DicomTag.ApplicationSetupManufacturer:
                case DicomTag.TemplateName:
                case DicomTag.BrachyAccessoryDeviceName:
                case DicomTag.SourceApplicatorName:
                case DicomTag.SourceApplicatorManufacturer:
                case DicomTag.ChannelShieldName:
                case DicomTag.ResultsIDIssuer:
                case DicomTag.ReferenceToRecordedSound:
                case DicomTag.DistributionAddress:
                case DicomTag.InterpretationIDIssuer:
                case DicomTag.ModifyingSystem:
                case DicomTag.SourceofPreviousValues:
                    return (int)VR.LO;

                case DicomTag.StudyCommentsRetired:
                case DicomTag.AdditionalPatientHistory:
                case DicomTag.PatientComments:
                case DicomTag.SeriesCommentsRetired:
                case DicomTag.DetectorDescription:
                case DicomTag.DetectorMode:
                case DicomTag.GridAbsorbingMaterial:
                case DicomTag.GridSpacingMaterial:
                case DicomTag.ExposureControlModeDescription:
                case DicomTag.ImageComments:
                case DicomTag.FrameComments:
                case DicomTag.PixelCommentsRetired:
                case DicomTag.StudyComments:
                case DicomTag.VisitComments:
                case DicomTag.SPSComments:
                case DicomTag.RequestedProcedureComments:
                case DicomTag.ImagingServiceRequestComments:
                case DicomTag.SOPAuthorizationComment:
                case DicomTag.ConfigurationInformationDescription:
                case DicomTag.FractionPattern:
                case DicomTag.ArbitraryRetired:
                case DicomTag.ArbitraryCommentsRetired:
                case DicomTag.InterpretationDiagnosisDescription:
                    return (int)VR.LT;

                case DicomTag.DataSetTrailingPadding:
                case DicomTag.CertificateOfSigner:
                case DicomTag.Signature:
                case DicomTag.CertifiedTimestamp:
                case DicomTag.MAC:
                case DicomTag.EncryptedContent:
                case DicomTag.FileMetaInformationVersion:
                case DicomTag.PrivateInformation:
                    return (int)VR.OB;

                case DicomTag.VectorGridData:
                case DicomTag.FirstOrderPhaseCorrectionAngle:
                case DicomTag.SpectroscopyData:
                    return (int)VR.OF;

                case DicomTag.RedPaletteColorLUTData:
                case DicomTag.GreenPaletteColorLUTData:
                case DicomTag.BluePaletteColorLUTData:
                case DicomTag.SegmentedRedPaletteColorLUTData:
                case DicomTag.SegmentedGreenPaletteColorLUTData:
                case DicomTag.SegmentedBluePaletteColorLUTData:
                case DicomTag.LUTData:
                case DicomTag.ChannelMinimumValue:
                case DicomTag.ChannelMaximumValue:
                case DicomTag.WaveformPaddingValue:
                case DicomTag.WaveformData:
                case DicomTag.PixelData:
                    return (int)VR.OW;

                case DicomTag.ReferringPhysicianName:
                case DicomTag.PhysicianOfRecord:
                case DicomTag.PerformingPhysicianName:
                case DicomTag.NameOfPhysicianReadingStudy:
                case DicomTag.OperatorName:
                case DicomTag.PatientName:
                case DicomTag.OtherPatientNames:
                case DicomTag.PatientBirthName:
                case DicomTag.PatientMotherBirthName:
                case DicomTag.RequestingPhysician:
                case DicomTag.ScheduledPerformingPhysicianName:
                case DicomTag.NamesOfIntendedRecipientsOfResults:
                case DicomTag.OrderEnteredBy:
                case DicomTag.VerifyingObserverName:
                case DicomTag.PersonName:
                case DicomTag.PresentationCreatorName:
                case DicomTag.ROIInterpreter:
                case DicomTag.ReviewerName:
                case DicomTag.InterpretationRecorder:
                case DicomTag.InterpretationTranscriber:
                case DicomTag.InterpretationAuthor:
                case DicomTag.PhysicianApprovingInterpretation:
                case DicomTag.DistributionName:
                    return (int)VR.PN;

                case DicomTag.AccessionNumber:
                case DicomTag.ReferringPhysicianPhoneNumbers:
                case DicomTag.CodeValue:
                case DicomTag.CodingSchemeDesignator:
                case DicomTag.CodingSchemeVersion:
                case DicomTag.TimezoneOffsetFromUTC:
                case DicomTag.StationName:
                case DicomTag.StageName:
                case DicomTag.PatientPhoneNumbers:
                case DicomTag.EthnicGroup:
                case DicomTag.Occupation:
                case DicomTag.SequenceName:
                case DicomTag.ImagedNucleus:
                case DicomTag.VideoImageFormatAcquired:
                case DicomTag.FilterType:
                case DicomTag.CollimatorGridName:
                case DicomTag.ConvolutionKernel:
                case DicomTag.ReceiveCoilName:
                case DicomTag.TransmitCoilName:
                case DicomTag.PlateType:
                case DicomTag.TimeSource:
                case DicomTag.OutputPower:
                case DicomTag.DetectorID:
                case DicomTag.PulseSequenceName:
                case DicomTag.MultiCoilElementName:
                case DicomTag.StudyID:
                case DicomTag.ModifyingDeviceIDRetired:
                case DicomTag.ModifiedImageIDRetired:
                case DicomTag.StackID:
                case DicomTag.MultiplexGroupLabel:
                case DicomTag.ChannelLabel:
                case DicomTag.SPSID:
                case DicomTag.ScheduledStationName:
                case DicomTag.SPSLocation:
                case DicomTag.PerformedStationName:
                case DicomTag.PerformedLocation:
                case DicomTag.PPSID:
                case DicomTag.RequestedProcedureID:
                case DicomTag.RequestedProcedurePriority:
                case DicomTag.PlacerOrderNumberProcedureRetired:
                case DicomTag.FillerOrderNumberProcedureRetired:
                case DicomTag.ReportingPriority:
                case DicomTag.PlacerOrderNumberImagingServiceRequestRetired:
                case DicomTag.FillerOrderNumberImagingServiceRequestRetired:
                case DicomTag.OrderEntererLocation:
                case DicomTag.OrderCallbackPhoneNumber:
                case DicomTag.EnergyWindowName:
                case DicomTag.ImageID:
                case DicomTag.StorageMediaFileSetID:
                case DicomTag.PrintJobID:
                case DicomTag.OwnerID:
                case DicomTag.PrintQueueID:
                case DicomTag.RTImageLabel:
                case DicomTag.RadiationMachineName:
                case DicomTag.StructureSetLabel:
                case DicomTag.ROIObservationLabel:
                case DicomTag.TreatmentTerminationCode:
                case DicomTag.RTPlanLabel:
                case DicomTag.ToleranceTableLabel:
                case DicomTag.TreatmentMachineName:
                case DicomTag.WedgeID:
                case DicomTag.MaterialID:
                case DicomTag.CompensatorID:
                case DicomTag.BlockTrayID:
                case DicomTag.ApplicatorID:
                case DicomTag.FixationDeviceLabel:
                case DicomTag.FixationDevicePosition:
                case DicomTag.ShieldingDeviceLabel:
                case DicomTag.ShieldingDevicePosition:
                case DicomTag.SetupDeviceLabel:
                case DicomTag.TemplateType:
                case DicomTag.BrachyAccessoryDeviceID:
                case DicomTag.SourceApplicatorID:
                case DicomTag.ChannelShieldID:
                case DicomTag.ResultsID:
                case DicomTag.InterpretationID:
                    return (int)VR.SH;

                case DicomTag.ReferencePixelX0:
                case DicomTag.ReferencePixelY0:
                case DicomTag.DisplayedAreaTopLeftHandCorner:
                case DicomTag.DisplayedAreaBottomRightHandCorner:
                    return (int)VR.SL;

                case DicomTag.InstitutionCodeSeq:
                case DicomTag.ProcedureCodeSeq:
                case DicomTag.AdmittingDiagnosisCodeSeq:
                case DicomTag.ReferringPhysicianIdentificationSequence:
                case DicomTag.RefResultsSeq:
                case DicomTag.RefStudySeq:
                //case DicomTag.RefStudyComponentSeq:
                case DicomTag.RefSeriesSeq:
                case DicomTag.RefPatientSeq:
                case DicomTag.PersonIdentificationCodeSeq:
                case DicomTag.CodingSchemeIdentificationSeq:
                case DicomTag.PhysiciansofRecordIdentificationSeq:
                case DicomTag.PerformingPhysicianIdentificationSeq:
                case DicomTag.PhysiciansReadingStudyIdentificationSeq:
                case DicomTag.ContributingEquipmentSeq:
                case DicomTag.PurposeofReferenceCodeSeq:
                case DicomTag.OperatorIdentificationSeq:
                case DicomTag.ReferencedWaveformSeq:
                case DicomTag.RefVisitSeq:
                case DicomTag.RefOverlaySeq:
                case DicomTag.RefImageSeq:
                case DicomTag.RefCurveSeq:
                case DicomTag.RefInstanceSeq:
                case DicomTag.FailedSOPSeq:
                case DicomTag.RefSOPSeq:
                case DicomTag.SourceImageSeq:
                case DicomTag.AnatomicRegionSeq:
                case DicomTag.AnatomicRegionModifierSeq:
                case DicomTag.PrimaryAnatomicStructureSeq:
                case DicomTag.AnatomicStructureSpaceRegionSeq:
                case DicomTag.PrimaryAnatomicStructureModifierSeq:
                case DicomTag.TransducerPositionSeq:
                case DicomTag.TransducerPositionModifierSeq:
                case DicomTag.TransducerOrientationSeq:
                case DicomTag.TransducerOrientationModifierSeq:
                case DicomTag.RefRawDataSeq:
                case DicomTag.DerivationImageSeq:
                case DicomTag.ReferringImageEvidenceSeq:
                case DicomTag.SourceImageEvidenceSeq:
                case DicomTag.DerivationCodeSeq:
                case DicomTag.RefGrayscalePresentationStateSeq:
                case DicomTag.PatientInsurancePlanCodeSeq:
                case DicomTag.ContrastBolusAgentSeq:
                case DicomTag.ContrastBolusAdministrationRouteSeq:
                case DicomTag.InterventionDrugInformationSeq:
                case DicomTag.InterventionDrugCodeSeq:
                case DicomTag.AdditionalDrugSeq:
                case DicomTag.InterventionalTherapySeq:
                case DicomTag.ProjectionEponymousNameCodeSeq:
                case DicomTag.SeqOfUltrasoundRegions:
                case DicomTag.MRImagingModifierSeq:
                case DicomTag.MRReceiveCoilSeq:
                case DicomTag.MultiCoilDefInitionSeq:
                case DicomTag.MRTransmitCoilSeq:
                case DicomTag.DiffusionGradientDirectionSeq:
                case DicomTag.ChemicalShiftSeq:
                case DicomTag.MRSpectroscopyFOVGeometrySeq:
                case DicomTag.MRSpatialSaturationSeq:
                case DicomTag.MRTimingAndRelatedParametersSeq:
                case DicomTag.MREchoSeq:
                case DicomTag.MRModifierSeq:
                case DicomTag.MRDiffusionSeq:
                case DicomTag.CardiacTriggerSeq:
                case DicomTag.MRAveragesSeq:
                case DicomTag.MRFOVGeometrySeq:
                case DicomTag.VolumeLocalizationSeq:
                case DicomTag.MetaboliteMapSeq:
                case DicomTag.OperationModeSeq:
                case DicomTag.MRVelocityEncodingSeq:
                case DicomTag.MRImageFrameTypeSeq:
                case DicomTag.MRSpectroscopyFrameTypeSeq:
                case DicomTag.SpecificAbsorptionRateSeq:
                case DicomTag.FrameAnatomySeq:
                case DicomTag.FrameContentSeq:
                case DicomTag.PlanePositionSeq:
                case DicomTag.PlaneOrientationSeq:
                case DicomTag.DimensionOrganizationSeq:
                case DicomTag.DimensionSeq:
                case DicomTag.ModalityLUTSeq:
                case DicomTag.VOILUTSeq:
                case DicomTag.SoftcopyVOILUTSeq:
                case DicomTag.BiPlaneAcquisitionSeq:
                case DicomTag.MaskSubtractionSeq:
                case DicomTag.PixelMatrixSeq:
                case DicomTag.FrameVOILUTSeq:
                case DicomTag.PixelValueTransformationSeq:
                case DicomTag.RequestedProcedureCodeSeq:
                case DicomTag.RefPatientAliasSeq:
                case DicomTag.DischargeDiagnosisCodeSeq:
                case DicomTag.ChannelDefInitionSeq:
                case DicomTag.ChannelSourceSeq:
                case DicomTag.ChannelSourceModifiersSeq:
                case DicomTag.SourceWaveformSeq:
                case DicomTag.ChannelSensitivityUnitsSeq:
                case DicomTag.ScheduledProtocolCodeSeq:
                case DicomTag.SPSSeq:
                case DicomTag.RefStandaloneSOPInstanceSeq:
                case DicomTag.PerformedProtocolCodeSeq:
                case DicomTag.ScheduledStepAttributesSeq:
                case DicomTag.RequestAttributesSeq:
                case DicomTag.PPSDiscontinuationReasonCodeSeq:
                case DicomTag.QuantitySeq:
                case DicomTag.MeasuringUnitsSeq:
                case DicomTag.BillingItemSeq:
                case DicomTag.BillingProcedureStepSeq:
                case DicomTag.FilmConsumptionSeq:
                case DicomTag.BillingSuppliesAndDevicesSeq:
                case DicomTag.RefProcedureStepSeq:
                case DicomTag.PerformedSeriesSeq:
                case DicomTag.SpecimenSeq:
                case DicomTag.SpecimenTypeCodeSeq:
                case DicomTag.AcquisitionContextSeq:
                case DicomTag.ImageCenterPointCoordinatesSeq:
                case DicomTag.PixelSpacingSeq:
                case DicomTag.CoordinateSystemAxisCodeSeq:
                case DicomTag.MeasurementUnitsCodeSeq:
                case DicomTag.ConceptNameCodeSeq:
                case DicomTag.VerifyingObserverSeq:
                case DicomTag.VerifyingObserverIdentificationCodeSeq:
                case DicomTag.ConceptCodeSeq:
                case DicomTag.ModifierCodeSeq:
                case DicomTag.MeasuredValueSeq:
                case DicomTag.PredecessorDocumentsSeq:
                case DicomTag.RefRequestSeq:
                case DicomTag.PerformedProcedureCodeSeq:
                case DicomTag.CurrentRequestedProcedureEvidenceSeq:
                case DicomTag.PertinentOtherEvidenceSeq:
                case DicomTag.ContentTemplateSeq:
                case DicomTag.IdenticalDocumentsSeq:
                case DicomTag.ContentSeq:
                case DicomTag.AnnotationSeq:
                case DicomTag.RealWorldValueMappingSeq:
                case DicomTag.DeviceSeq:
                case DicomTag.EnergyWindowInformationSeq:
                case DicomTag.EnergyWindowRangeSeq:
                case DicomTag.RadiopharmaceuticalInformationSeq:
                case DicomTag.DetectorInformationSeq:
                case DicomTag.PhaseInformationSeq:
                case DicomTag.RotationInformationSeq:
                case DicomTag.GatedInformationSeq:
                case DicomTag.DataInformationSeq:
                case DicomTag.TimeSlotInformationSeq:
                case DicomTag.ViewCodeSeq:
                case DicomTag.ViewModifierCodeSeq:
                case DicomTag.RadionuclideCodeSeq:
                case DicomTag.AdministrationRouteCodeSeq:
                case DicomTag.RadiopharmaceuticalCodeSeq:
                case DicomTag.CalibrationDataSeq:
                case DicomTag.PatientOrientationCodeSeq:
                case DicomTag.PatientOrientationModifierCodeSeq:
                case DicomTag.PatientGantryRelationshipCodeSeq:
                case DicomTag.HistogramSeq:
                case DicomTag.GraphicAnnotationSeq:
                case DicomTag.TextObjectSeq:
                case DicomTag.GraphicObjectSeq:
                case DicomTag.DisplayedAreaSelectionSeq:
                case DicomTag.GraphicLayerSeq:
                case DicomTag.IconImageSeq:
                case DicomTag.PrinterConfigurationSeq:
                case DicomTag.MediaInstalledSeq:
                case DicomTag.OtherMediaAvailableSeq:
                case DicomTag.SupportedImageDisplayFormatsSeq:
                case DicomTag.RefFilmBoxSeq:
                case DicomTag.RefStoredPrintSeq:
                case DicomTag.RefFilmSessionSeq:
                case DicomTag.RefImageBoxSeq:
                case DicomTag.RefBasicAnnotationBoxSeq:
                case DicomTag.BasicGrayscaleImageSeq:
                case DicomTag.BasicColorImageSeq:
                case DicomTag.RefImageOverlayBoxSeqRetired:
                case DicomTag.RefVOILUTBoxSeqRetired:
                case DicomTag.RefOverlayPlaneSeq:
                case DicomTag.OverlayPixelDataSeq:
                case DicomTag.RefImageBoxSeqRetired:
                case DicomTag.PresentationLUTSeq:
                case DicomTag.RefPresentationLUTSeq:
                case DicomTag.RefPrintJobSeq:
                case DicomTag.PrintJobDescriptionSeq:
                case DicomTag.RefPrintJobSeqInQueue:
                case DicomTag.PrintManagementCapabilitiesSeq:
                case DicomTag.PrinterCharacteristicsSeq:
                case DicomTag.FilmBoxContentSeq:
                case DicomTag.ImageBoxContentSeq:
                case DicomTag.AnnotationContentSeq:
                case DicomTag.ImageOverlayBoxContentSeq:
                case DicomTag.PresentationLUTContentSeq:
                case DicomTag.ProposedStudySeq:
                case DicomTag.OriginalImageSeq:
                case DicomTag.ExposureSeq:
                case DicomTag.RTDoseROISeq:
                case DicomTag.DVHSeq:
                case DicomTag.DVHRefROISeq:
                case DicomTag.RefFrameOfReferenceSeq:
                case DicomTag.RTRefStudySeq:
                case DicomTag.RTRefSeriesSeq:
                case DicomTag.ContourImageSeq:
                case DicomTag.StructureSetROISeq:
                case DicomTag.RTRelatedROISeq:
                case DicomTag.ROIContourSeq:
                case DicomTag.ContourSeq:
                case DicomTag.RTROIObservationsSeq:
                case DicomTag.RTROIIdentificationCodeSeq:
                case DicomTag.RelatedRTROIObservationsSeq:
                case DicomTag.ROIPhysicalPropertiesSeq:
                case DicomTag.FrameOfReferenceRelationshipSeq:
                case DicomTag.MeasuredDoseReferenceSeq:
                case DicomTag.TreatmentSessionBeamSeq:
                case DicomTag.RefTreatmentRecordSeq:
                case DicomTag.ControlPointDeliverySeq:
                case DicomTag.TreatmentSummaryCalculatedDoseReferenceSeq:
                case DicomTag.OverrideSeq:
                case DicomTag.CalculatedDoseReferenceSeq:
                case DicomTag.RefMeasuredDoseReferenceSeq:
                case DicomTag.RefCalculatedDoseReferenceSeq:
                case DicomTag.BeamLimitingDeviceLeafPairsSeq:
                case DicomTag.RecordedWedgeSeq:
                case DicomTag.RecordedCompensatorSeq:
                case DicomTag.RecordedBlockSeq:
                case DicomTag.TreatmentSummaryMeasuredDoseReferenceSeq:
                case DicomTag.RecordedSourceSeq:
                case DicomTag.TreatmentSessionApplicationSetupSeq:
                case DicomTag.RecordedBrachyAccessoryDeviceSeq:
                case DicomTag.RecordedChannelSeq:
                case DicomTag.RecordedSourceApplicatorSeq:
                case DicomTag.RecordedChannelShieldSeq:
                case DicomTag.BrachyControlPointDeliveredSeq:
                case DicomTag.FractionGroupSummarySeq:
                case DicomTag.FractionStatusSummarySeq:
                case DicomTag.DoseReferenceSeq:
                case DicomTag.ToleranceTableSeq:
                case DicomTag.BeamLimitingDeviceToleranceSeq:
                case DicomTag.FractionGroupSeq:
                case DicomTag.BeamSeq:
                case DicomTag.BeamLimitingDeviceSeq:
                case DicomTag.PlannedVerificationImageSeq:
                case DicomTag.WedgeSeq:
                case DicomTag.CompensatorSeq:
                case DicomTag.BlockSeq:
                case DicomTag.ApplicatorSeq:
                case DicomTag.ControlPointSeq:
                case DicomTag.WedgePositionSeq:
                case DicomTag.BeamLimitingDevicePositionSeq:
                case DicomTag.PatientSetupSeq:
                case DicomTag.FixationDeviceSeq:
                case DicomTag.ShieldingDeviceSeq:
                case DicomTag.SetupDeviceSeq:
                case DicomTag.TreatmentMachineSeq:
                case DicomTag.SourceSeq:
                case DicomTag.ApplicationSetupSeq:
                case DicomTag.BrachyAccessoryDeviceSeq:
                case DicomTag.ChannelSeq:
                case DicomTag.ChannelShieldSeq:
                case DicomTag.BrachyControlPointSeq:
                case DicomTag.RefRTPlanSeq:
                case DicomTag.RefBeamSeq:
                case DicomTag.RefBrachyApplicationSetupSeq:
                case DicomTag.RefFractionGroupSeq:
                case DicomTag.RefVerificationImageSeq:
                case DicomTag.RefReferenceImageSeq:
                case DicomTag.RefDoseReferenceSeq:
                case DicomTag.BrachyRefDoseReferenceSeq:
                case DicomTag.RefStructureSetSeq:
                case DicomTag.RefDoseSeq:
                case DicomTag.RefBolusSeq:
                case DicomTag.RefInterpretationSeq:
                case DicomTag.InterpretationApproverSeq:
                case DicomTag.InterpretationDiagnosisCodeSeq:
                case DicomTag.ResultsDistributionListSeq:
                case DicomTag.SharedFunctionalGroupsSeq:
                case DicomTag.PerFrameFunctionalGroupsSeq:
                case DicomTag.WaveformSeq:
                case DicomTag.DigitalSignaturePurposeCodeSeq:
                case DicomTag.ReferencedDigitalSignatureSeq:
                case DicomTag.ReferencedSOPInstanceMACSeq:
                case DicomTag.EncryptedAttributesSeq:
                case DicomTag.ModifiedAttributesSeq:
                case DicomTag.OriginalAttributesSeq:
                case DicomTag.MACParametersSeq:
                case DicomTag.DeformableRegistrationSequence:
                case DicomTag.DeformableRegistrationGridSequence:
                case DicomTag.PreDeformationMatrixRegistrationSequence:
                case DicomTag.PostDeformationMatrixRegistrationSequence:
                case DicomTag.PresentationTextStyleSeq:
                case DicomTag.LineStyleSequence:
                   
                    return (int)VR.SQ;

                case DicomTag.TagSpacingSecondDimension:
                case DicomTag.TagAngleSecondAxis:
                case DicomTag.PixelIntensityRelationshipSign:
                case DicomTag.TIDOffset:
                case DicomTag.LUTLabel:
                    return (int)VR.SS;

                case DicomTag.InstitutionAddress:
                case DicomTag.ReferringPhysicianAddress:
                case DicomTag.DerivationDescription:
                case DicomTag.MetaboliteMapDescription:
                case DicomTag.PartialViewDescription:
                case DicomTag.MaskOperationExplanation:
                case DicomTag.PPSComments:
                case DicomTag.CommentsOnRadiationDose:
                case DicomTag.AcquisitionContextDescription:
                case DicomTag.UnformattedTextValue:
                case DicomTag.TopicSubject:
                case DicomTag.ImageDisplayFormat:
                case DicomTag.ConfigurationInformation:
                case DicomTag.RTImageDescription:
                case DicomTag.StructureSetDescription:
                case DicomTag.ROIDescription:
                case DicomTag.ROIObservationDescription:
                case DicomTag.MeasuredDoseDescription:
                case DicomTag.OverrideReason:
                case DicomTag.CalculatedDoseReferenceDescription:
                case DicomTag.TreatmentStatusComment:
                case DicomTag.RTPlanDescription:
                case DicomTag.PrescriptionDescription:
                case DicomTag.BeamDescription:
                case DicomTag.FixationDeviceDescription:
                case DicomTag.ShieldingDeviceDescription:
                case DicomTag.SetupTechniqueDescription:
                case DicomTag.SetupDeviceDescription:
                case DicomTag.SetupReferenceDescription:
                case DicomTag.InterpretationText:
                case DicomTag.Impressions:
                case DicomTag.ResultsComments:
                case DicomTag.ContributionDescriptionST:
                    return (int)VR.ST;

                case DicomTag.InstanceCreationTime:
                case DicomTag.StudyTime:
                case DicomTag.SeriesTime:
                case DicomTag.AcquisitionTime:
                case DicomTag.ContentTime:
                case DicomTag.OverlayTime:
                case DicomTag.CurveTime:
                case DicomTag.PatientBirthTime:
                case DicomTag.InterventionDrugStopTime:
                case DicomTag.InterventionDrugStartTime:
                case DicomTag.TimeOfSecondaryCapture:
                case DicomTag.ContrastBolusStartTime:
                case DicomTag.ContrastBolusStopTime:
                case DicomTag.RadiopharmaceuticalStartTime:
                case DicomTag.RadiopharmaceuticalStopTime:
                case DicomTag.TimeOfLastCalibration:
                case DicomTag.TimeOfLastDetectorCalibration:
                case DicomTag.ModifiedImageTimeRetired:
                case DicomTag.StudyVerifiedTime:
                case DicomTag.StudyReadTime:
                case DicomTag.ScheduledStudyStartTime:
                case DicomTag.ScheduledStudyStopTime:
                case DicomTag.StudyArrivalTime:
                case DicomTag.StudyCompletionTime:
                case DicomTag.ScheduledAdmissionTime:
                case DicomTag.ScheduledDischargeTime:
                case DicomTag.AdmittingTime:
                case DicomTag.DischargeTime:
                case DicomTag.SPSStartTime:
                case DicomTag.SPSEndTime:
                case DicomTag.PPSStartTime:
                case DicomTag.PPSEndTime:
                case DicomTag.IssueTimeOfImagingServiceRequest:
                case DicomTag.Time:
                case DicomTag.PresentationCreationTime:
                case DicomTag.CreationTime:
                case DicomTag.StructureSetTime:
                case DicomTag.TreatmentControlPointTime:
                case DicomTag.SafePositionExitTime:
                case DicomTag.SafePositionReturnTime:
                case DicomTag.TreatmentTime:
                case DicomTag.RTPlanTime:
                case DicomTag.AirKermaRateReferenceTime:
                case DicomTag.ReviewTime:
                case DicomTag.InterpretationRecordedTime:
                case DicomTag.InterpretationTranscriptionTime:
                case DicomTag.InterpretationApprovalTime:
                    return (int)VR.TM;

                case DicomTag.InstanceCreatorUID:
                case DicomTag.SOPClassUID:
                case DicomTag.SOPInstanceUID:
                case DicomTag.FailedSOPInstanceUIDList:
                case DicomTag.SOPClassesInStudy:
                case DicomTag.PrivateCodingSchemeCreatorUID:
                case DicomTag.CodeSetExtensionCreatorUID:
                case DicomTag.RefSOPClassUID:
                case DicomTag.RefSOPInstanceUID:
                case DicomTag.SOPClassesSupported:
                case DicomTag.TransactionUID:
                case DicomTag.CreatorVersionUID:
                case DicomTag.StudyInstanceUID:
                case DicomTag.SeriesInstanceUID:
                case DicomTag.FrameOfReferenceUID:
                case DicomTag.SynchronizationFrameOfReferenceUID:
                case DicomTag.ConcatenationUID:
                case DicomTag.DimensionOrganizationUID:
                case DicomTag.PaletteColorLUTUID:
                case DicomTag.UID:
                case DicomTag.TemplateExtensionOrganizationUID:
                case DicomTag.TemplateExtensionCreatorUID:
                case DicomTag.StorageMediaFileSetUID:
                case DicomTag.RefFrameOfReferenceUID:
                case DicomTag.RelatedFrameOfReferenceUID:
                case DicomTag.MACCalculationTransferSyntaxUID:
                case DicomTag.EncryptedContentTransferSyntaxUID:
                case DicomTag.DigitalSignatureUID:
                    return (int)VR.UI;

                case DicomTag.TriggerSamplePosition:
                case DicomTag.RegionFlags:
                case DicomTag.RegionLocationMinX0:
                case DicomTag.RegionLocationMinY0:
                case DicomTag.RegionLocationMaxX1:
                case DicomTag.RegionLocationMaxY1:
                case DicomTag.TransducerFrequency:
                case DicomTag.PulseRepetitionFrequency:
                case DicomTag.DopplerSampleVolumeXPosition:
                case DicomTag.DopplerSampleVolumeYPosition:
                case DicomTag.TMLinePositionX0:
                case DicomTag.TMLinePositionY0:
                case DicomTag.TMLinePositionX1:
                case DicomTag.TMLinePositionY1:
                case DicomTag.PixelComponentMask:
                case DicomTag.PixelComponentRangeStart:
                case DicomTag.PixelComponentRangeStop:
                case DicomTag.NumberOfTableBreakPoints:
                case DicomTag.TableOfXBreakPoints:
                case DicomTag.NumberOfTableEntries:
                case DicomTag.TableOfPixelValues:
                case DicomTag.SpectroscopyAcquisitionPhaseRows:
                case DicomTag.SpectroscopyAcquisitionDataColumns:
                case DicomTag.SpectroscopyAcquisitionOutOfPlanePhaseSteps:
                case DicomTag.SpectroscopyAcquisitionPhaseColumns:
                case DicomTag.InStackPositionNumber:
                case DicomTag.TemporalPositionIndex:
                case DicomTag.DimensionIndexValues:
                case DicomTag.ConcatenationFrameOffsetNumber:
                case DicomTag.DataPointRows:
                case DicomTag.DataPointColumns:
                case DicomTag.NumberOfWaveformSamples:
                case DicomTag.RefSamplePositions:
                case DicomTag.RefContentItemIdentifier:
                case DicomTag.HistogramData:
                case DicomTag.GridDimensions:
                case DicomTag.LinePattern:
                    return (int)VR.UL;

                case DicomTag.LengthToEndRetired:
                case DicomTag.RecognitionCodeRetired:
                case DicomTag.DataSetTypeRetired:
                case DicomTag.DataSetSubtypeRetired:
                case DicomTag.NetworkIDRetired:
                case DicomTag.VolumetricProperties:
                case DicomTag.UpperLowerPixelValuesRetired:
                case DicomTag.DynamicRangeRetired:
                case DicomTag.TotalGainRetired:
                case DicomTag.LocationRetired:
                case DicomTag.ReferenceRetired:
                case DicomTag.ImageDimensionsRetired:
                case DicomTag.ImageFormatRetired:
                case DicomTag.ManipulatedImageRetired:
                case DicomTag.ImageLocationRetired:
                case DicomTag.GrayScaleRetired:
                    return (int)VR.UN;

                case DicomTag.FailureReason:
                case DicomTag.PregnancyStatus:
                case DicomTag.SynchronizationChannel:
                case DicomTag.PreferredPlaybackSequencing:
                case DicomTag.AcquisitionMatrix:
                case DicomTag.ExposuresOnPlate:
                case DicomTag.ShutterPresentationValue:
                case DicomTag.ShutterOverlayGroup:
                case DicomTag.RegionSpatialFormat:
                case DicomTag.RegionDataType:
                case DicomTag.PhysicalUnitsXDirection:
                case DicomTag.PhysicalUnitsYDirection:
                case DicomTag.PixelComponentOrganization:
                case DicomTag.PixelComponentPhysicalUnits:
                case DicomTag.PixelComponentDataType:
                case DicomTag.MRAcquisitionFrequencyEncodingSteps:
                case DicomTag.NumberOfZeroFills:
                case DicomTag.NumberOfKSpaceTrajectories:
                case DicomTag.MRAcquisitionPhaseEncodingStepsInPlane:
                case DicomTag.MRAcquisitionPhaseEncodingStepsOutOfPlane:
                case DicomTag.FrameAcquisitionNumber:
                case DicomTag.InConcatenationNumber:
                case DicomTag.InConcatenationTotalNumber:
                case DicomTag.SamplesPerPixel:
                case DicomTag.PlanarConfiguration:
                case DicomTag.Rows:
                case DicomTag.Columns:
                case DicomTag.Planes:
                case DicomTag.UltrasoundColorDataPresent:
                case DicomTag.BitsAllocated:
                case DicomTag.BitsStored:
                case DicomTag.HighBit:
                case DicomTag.PixelRepresentation:
                case DicomTag.SmallestValidPixelValueRetired:
                case DicomTag.LargestValidPixelValueRetired:
                case DicomTag.SmallestImagePixelValue:
                case DicomTag.LargestImagePixelValue:
                case DicomTag.SmallestPixelValueInSeries:
                case DicomTag.LargestPixelValueInSeries:
                case DicomTag.SmallestImagePixelValueInPlane:
                case DicomTag.LargestImagePixelValueInPlane:
                case DicomTag.PixelPaddingValue:
                case DicomTag.GreyLUTDescriptorRetired:
                case DicomTag.RedPaletteColorLUTDescriptor:
                case DicomTag.GreenPaletteColorLUTDescriptor:
                case DicomTag.BluePaletteColorLUTDescriptor:
                case DicomTag.LUTDescriptor:
                case DicomTag.RepresentativeFrameNumber:
                case DicomTag.FrameNumbersOfInterest:
                case DicomTag.MaskPointer:
                case DicomTag.RWavePointer:
                case DicomTag.ApplicableFrameRange:
                case DicomTag.MaskFrameNumbers:
                case DicomTag.ContrastFrameAveraging:
                case DicomTag.LargestMonochromePixelValue:
                case DicomTag.NumberOfWaveformChannels:
                case DicomTag.WaveformBitsStored:
                case DicomTag.TotalTimeOfFluoroscopy:
                case DicomTag.TotalNumberOfExposures:
                case DicomTag.EntranceDose:
                case DicomTag.ExposedArea:
                case DicomTag.RefWaveformChannels:
                case DicomTag.RefFrameNumbers:
                case DicomTag.AnnotationGroupNumber:
                case DicomTag.RealWorldValueLUTLastValueMappedUS:
                case DicomTag.RealWorldValueLUTFirstValueMappedUS:
                case DicomTag.EnergyWindowVector:
                case DicomTag.NumberOfEnergyWindows:
                case DicomTag.DetectorVector:
                case DicomTag.NumberOfDetectors:
                case DicomTag.PhaseVector:
                case DicomTag.NumberOfPhases:
                case DicomTag.NumberOfFramesInPhase:
                case DicomTag.RotationVector:
                case DicomTag.NumberOfRotations:
                case DicomTag.NumberOfFramesInRotation:
                case DicomTag.RRIntervalVector:
                case DicomTag.NumberOfRRIntervals:
                case DicomTag.TimeSlotVector:
                case DicomTag.NumberOfTimeSlots:
                case DicomTag.SliceVector:
                case DicomTag.NumberOfSlices:
                case DicomTag.AngularViewVector:
                case DicomTag.TimeSliceVector:
                case DicomTag.NumberOfTimeSlices:
                case DicomTag.NumberOfTriggersInPhase:
                case DicomTag.EnergyWindowNumber:
                case DicomTag.ImageIndex:
                case DicomTag.HistogramNumberOfBins:
                case DicomTag.HistogramFirstBinValue:
                case DicomTag.HistogramLastBinValue:
                case DicomTag.HistogramBinWidth:
                case DicomTag.GraphicDimensions:
                case DicomTag.NumberOfGraphicPoints:
                case DicomTag.ImageRotation:
                case DicomTag.GraphicLayerRecommendedDisplayGrayscaleValue:
                case DicomTag.GraphicLayerRecommendedDisplayRGBValue:
                case DicomTag.MemoryBitDepth:
                case DicomTag.PrintingBitDepth:
                case DicomTag.MinDensity:
                case DicomTag.MaxDensity:
                case DicomTag.Illumination:
                case DicomTag.ReflectedAmbientLight:
                case DicomTag.ImagePositionOnFilm:
                case DicomTag.AnnotationPosition:
                case DicomTag.RefOverlayPlaneGroups:
                case DicomTag.MagnifyToNumberOfColumns:
                case DicomTag.WaveformBitsAllocated:
                case DicomTag.MACIDNumber:
                case DicomTag.TextColorCIELab:
                case DicomTag.ShadowColorCIELab:
                case DicomTag.PatternOnColorCIELabValue:
                case DicomTag.PatternOffColorCIELabValue:
                    return (int)VR.US;

                case DicomTag.TextValue:
                    return (int)VR.UT;

                case DicomTag.Item:
                case DicomTag.ItemDelimitationItem:
                case DicomTag.SeqDelimitationItem:
                    return (int)VR.NONE;

            }
            switch (tag & 0xFF00FFFF)
            {
                case DicomTag.TypeOfData:
                case DicomTag.CurveActivationLayer:
                case DicomTag.OverlayType:
                case DicomTag.OverlayCompressionCodeRetired:
                case DicomTag.OverlayFormatRetired:
                case DicomTag.OverlayActivationLayer:
                    return (int)VR.CS;

                case DicomTag.ROIMean:
                case DicomTag.ROIStandardDeviation:
                    return (int)VR.DS;

                case DicomTag.NumberOfFramesInOverlay:
                case DicomTag.ROIArea:
                    return (int)VR.IS;

                case DicomTag.CurveDescription:
                case DicomTag.CurveLabel:
                case DicomTag.OverlayDescription:
                case DicomTag.OverlaySubtype:
                case DicomTag.OverlayLabel:
                    return (int)VR.LO;

                case DicomTag.AudioComments:
                case DicomTag.OverlayCommentsRetired:
                    return (int)VR.LT;

                case DicomTag.CurveData:
                    return (int)VR.OB;

                case DicomTag.AudioSampleData:
                case DicomTag.OverlayData:
                    return (int)VR.OW;

                case DicomTag.AxisUnits:
                case DicomTag.AxisLabels:
                case DicomTag.CurveRange:
                    return (int)VR.SH;

                case DicomTag.RefOverlaySeqCurve:
                    return (int)VR.SQ;

                case DicomTag.OverlayOrigin:
                    return (int)VR.SS;

                case DicomTag.NumberOfSamples:
                case DicomTag.SampleRate:
                case DicomTag.TotalTime:
                    return (int)VR.UL;

                case DicomTag.OverlayLocationRetired:
                    return (int)VR.UN;

                case DicomTag.CurveDimensions:
                case DicomTag.NumberOfPoints:
                case DicomTag.DataValueRepresentation:
                case DicomTag.MinimumCoordinateValue:
                case DicomTag.MaximumCoordinateValue:
                case DicomTag.CurveDataDescriptor:
                case DicomTag.CoordinateStartValue:
                case DicomTag.CoordinateStepValue:
                case DicomTag.AudioType:
                case DicomTag.AudioSampleFormat:
                case DicomTag.NumberOfChannels:
                case DicomTag.RefOverlayGroup:
                case DicomTag.OverlayRows:
                case DicomTag.OverlayColumns:
                case DicomTag.OverlayPlanes:
                case DicomTag.ImageFrameOrigin:
                case DicomTag.OverlayPlaneOrigin:
                case DicomTag.OverlayBitsAllocated:
                case DicomTag.OverlayBitPosition:
                case DicomTag.OverlayDescriptorGrayRetired:
                case DicomTag.OverlayDescriptorRedRetired:
                case DicomTag.OverlayDescriptorGreenRetired:
                case DicomTag.OverlayDescriptorBlueRetired:
                case DicomTag.OverlaysGrayRetired:
                case DicomTag.OverlaysRedRetired:
                case DicomTag.OverlaysGreenRetired:
                case DicomTag.OverlaysBlueRetired:
                    return (int)VR.US;

            }
            switch (tag & 0xFFFFFF00)
            {
                case DicomTag.SourceImageIDRetired:
                    return (int)VR.SH;

            }
            return (int)VR.UN;
        }
    }
}
