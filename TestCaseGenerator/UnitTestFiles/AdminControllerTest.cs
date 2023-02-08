using Xunit;
namespace UnitTestGenerator
{
    public class TestMethods
    {
        [Fact]
        public void GetListOfVendorsTest()
        {
          // Act
          var response = GetListOfVendors();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CreateVendorTest()
        {
          // Act
          var response = CreateVendor();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetStringValueTest()
        {
          // Act
          var response = GetStringValue();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void DeleteVendorStudentsTest()
        {
          // Arrange
          string vendorId;

          // Act
          var response = DeleteVendorStudents(vendorId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void DeleteExamInstancesTest()
        {
          // Arrange
          string userId;
          string examType;

          // Act
          var response = DeleteExamInstances(userId, examType);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CreateLawSchoolSuccessOrderAndAssignProductTest()
        {
          // Arrange
          CybersourceAuthorization cybersourceAuthorization;

          // Act
          var response = CreateLawSchoolSuccessOrderAndAssignProduct(cybersourceAuthorization);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void AddExamPasswordTest()
        {
          // Arrange
          string examProductId;
          ExamPasswordDto examPassword;

          // Act
          var response = AddExamPassword(examProductId, examPassword);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void AddExamDistributionTest()
        {
          // Act
          var response = AddExamDistribution();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetFutureExamsTest()
        {
          // Act
          var response = GetFutureExams();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CreateExamPlaceholderProductTest()
        {
          // Arrange
          LSATExamImportDto examImport;

          // Act
          var response = CreateExamPlaceholderProduct(examImport);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetTestResultTest()
        {
          // Arrange
          string userId;
          string testInstanceId;

          // Act
          var response = GetTestResult(userId, testInstanceId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetVendorTestResultTest()
        {
          // Arrange
          string userId;
          string testInstanceId;

          // Act
          var response = GetVendorTestResult(userId, testInstanceId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void DeleteVendorStudentTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = DeleteVendorStudent(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RefundDeactivateStudentTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;
          DateTime? backDateTime;

          // Act
          var response = RefundDeactivateStudent(vendorId, studentCoachingId, backDateTime);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void MarkRefundTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = MarkRefund(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UploadStudentDataTest()
        {
          // Arrange
          UploadStudentDataDto csvFile;

          // Act
          var response = UploadStudentData(csvFile);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void ProcessUploadedFileTest()
        {
          // Arrange
          string vendorId;
          string fileId;

          // Act
          var response = ProcessUploadedFile(vendorId, fileId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetBulkImportDataStatusTest()
        {
          // Arrange
          string vendorId;

          // Act
          var response = GetBulkImportDataStatus(vendorId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetProcessedRecordsTest()
        {
          // Arrange
          string vendorId;
          string fileId;

          // Act
          var response = GetProcessedRecords(vendorId, fileId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetUserTestInstanceSummaryTest()
        {
          // Arrange
          string userId;
          string testInstanceId;

          // Act
          var response = GetUserTestInstanceSummary(userId, testInstanceId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void MergeUserAccountsTest()
        {
          // Arrange
          string userId;
          string mergeFromUserId;

          // Act
          var response = MergeUserAccounts(userId, mergeFromUserId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetListOfUserOrganizationIdentifiersTest()
        {
          // Act
          var response = GetListOfUserOrganizationIdentifiers();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetAllUsersTest()
        {
          // Act
          var response = GetAllUsers();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetAllUserOrderHoldTest()
        {
          // Act
          var response = GetAllUserOrderHold();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RecreateUserOrderTest()
        {
          // Arrange
          string userId;

          // Act
          var response = RecreateUserOrder(userId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void MigrateUserOrdersTest()
        {
          // Arrange
          string userId;

          // Act
          var response = MigrateUserOrders(userId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateStudentSubscriptionDatesTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = UpdateStudentSubscriptionDates(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetUserTestHistoryTest()
        {
          // Arrange
          string userId;
          TestHistoryFilteringModel testHistoryFilteringModel;

          // Act
          var response = GetUserTestHistory(userId, testHistoryFilteringModel);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetUserTestScoreTest()
        {
          // Arrange
          string userId;
          string testInstanceId;

          // Act
          var response = GetUserTestScore(userId, testInstanceId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetUserTestReportPdfTest()
        {
          // Act
          var response = GetUserTestReportPdf();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GenerateVendorOrderByStudentCoachingIdTest()
        {
          // Act
          var response = GenerateVendorOrderByStudentCoachingId();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateFeeWaiverVendorOrdersTest()
        {
          // Act
          var response = UpdateFeeWaiverVendorOrders();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdatePrepaidStudentVendorOrderTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = UpdatePrepaidStudentVendorOrder(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RenewOrStudentAndSendViolationEmailTest()
        {
          // Arrange
          string vendorId;
          VendorRequestOrderDto vendorRequestOrderDto;

          // Act
          var response = RenewOrStudentAndSendViolationEmail(vendorId, vendorRequestOrderDto);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void SendVendorViolationEmailTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = SendVendorViolationEmail(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateSubscriptionDatesPrepOnlyTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = UpdateSubscriptionDatesPrepOnly(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RedeemUnredeemersTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;

          // Act
          var response = RedeemUnredeemers(vendorId, studentCoachingId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void AddExamCertifyingStatementTest()
        {
          // Arrange
          string examProductId;
          ExamCertifyingStatementDto examCertifyingStatement;

          // Act
          var response = AddExamCertifyingStatement(examProductId, examCertifyingStatement);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVendorTypeTest()
        {
          // Arrange
          string vendorId;
          string vendorType;

          // Act
          var response = UpdateVendorType(vendorId, vendorType);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVendorNegotiatedCoachingRateTest()
        {
          // Arrange
          string vendorId;
          decimal negotiatedCoachingRate;

          // Act
          var response = UpdateVendorNegotiatedCoachingRate(vendorId, negotiatedCoachingRate);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CorrectUserProgramDesignationTest()
        {
          // Arrange
          string userId;
          string programId;

          // Act
          var response = CorrectUserProgramDesignation(userId, programId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CreateVendorOrderfromUserOrderTest()
        {
          // Arrange
          string vendorId;
          string userId;
          string userOrderId;

          // Act
          var response = CreateVendorOrderfromUserOrder(vendorId, userId, userOrderId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CreateUserOrderHoldTest()
        {
          // Act
          var response = CreateUserOrderHold();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void AddDefaultExamSettingsTest()
        {
          // Act
          var response = AddDefaultExamSettings();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RemoveUserOrderHoldTest()
        {
          // Arrange
          string userId;
          string orderId;

          // Act
          var response = RemoveUserOrderHold(userId, orderId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetUserExamWritingSettingsTest()
        {
          // Arrange
          string userId;

          // Act
          var response = GetUserExamWritingSettings(userId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CreateUserExamWritingSettingsTest()
        {
          // Arrange
          string userId;
          UserWritingExamSettingsDto userWritingExamSettingsDto;

          // Act
          var response = CreateUserExamWritingSettings(userId, userWritingExamSettingsDto);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateUserExamWritingSettingsTest()
        {
          // Arrange
          string userId;
          UserWritingExamSettingsDto userWritingExamSettingsDto;

          // Act
          var response = UpdateUserExamWritingSettings(userId, userWritingExamSettingsDto);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void CancelWritingExamAndReservationTest()
        {
          // Arrange
          string userId;
          string examId;

          // Act
          var response = CancelWritingExamAndReservation(userId, examId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void SeparateSectionModulesTest()
        {
          // Arrange
          string moduleId;

          // Act
          var response = SeparateSectionModules(moduleId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVendorOrderbyOrderIdTest()
        {
          // Arrange
          string vendorId;
          string orderId;

          // Act
          var response = UpdateVendorOrderbyOrderId(vendorId, orderId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void AddExamStorageTableRecordsTest()
        {
          // Arrange
          List<ExamStorageTableRecordDto> examStorageTableRecords;

          // Act
          var response = AddExamStorageTableRecords(examStorageTableRecords);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetDefaultExamSettingsTest()
        {
          // Arrange
          string examProductId;

          // Act
          var response = GetDefaultExamSettings(examProductId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetExamDistributionTest()
        {
          // Arrange
          string examProductId;

          // Act
          var response = GetExamDistribution(examProductId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetExamUsageRecordsTest()
        {
          // Arrange
          string examProductId;

          // Act
          var response = GetExamUsageRecords(examProductId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RefundVendorOrderTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;
          string orderId;

          // Act
          var response = RefundVendorOrder(vendorId, studentCoachingId, orderId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void RefundOrderbyProductTest()
        {
          // Arrange
          string vendorId;
          string studentCoachingId;
          string orderId;
          string productId;

          // Act
          var response = RefundOrderbyProduct(vendorId, studentCoachingId, orderId, productId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetUserExamIncidentTest()
        {
          // Arrange
          string userId;
          string adminDate;
          int adminSequenceNumber;

          // Act
          var response = GetUserExamIncident(userId, adminDate, adminSequenceNumber);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void ResetExamSectionStartTimeTest()
        {
          // Arrange
          string userId;

          // Act
          var response = ResetExamSectionStartTime(userId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetPagedUsersTest()
        {
          // Act
          var response = GetPagedUsers();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetPaginatedActivitiesTest()
        {
          // Arrange
          UserActivitiesFilterModel userActivitiesFilterModel;

          // Act
          var response = GetPaginatedActivities(userActivitiesFilterModel);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetExamCertifyingStatementTest()
        {
          // Arrange
          string examProductId;

          // Act
          var response = GetExamCertifyingStatement(examProductId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void VerifyExamPasswordSetupTest()
        {
          // Arrange
          string examProductId;
          string examPassword;

          // Act
          var response = VerifyExamPasswordSetup(examProductId, examPassword);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVolumeDistributionExpectedTestTakersTest()
        {
          // Act
          var response = UpdateVolumeDistributionExpectedTestTakers();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void ResetUserExamTestInstanceStateBrowserValueTest()
        {
          // Act
          var response = ResetUserExamTestInstanceStateBrowserValue();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void AddModuleToProductTest()
        {
          // Arrange
          ModuleDto moduleDto;
          string productId;

          // Act
          var response = AddModuleToProduct(moduleDto, productId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetExamInstanceInfoTest()
        {
          // Arrange
          string userId;
          string examProductId;

          // Act
          var response = GetExamInstanceInfo(userId, examProductId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetProctoringReservationsTest()
        {
          // Arrange
          string userId;

          // Act
          var response = GetProctoringReservations(userId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateReferenceCodeByOrderIdTest()
        {
          // Arrange
          string vendorId;
          string orderId;

          // Act
          var response = UpdateReferenceCodeByOrderId(vendorId, orderId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVendorProductOfferTest()
        {
          // Arrange
          NewVendorDto newVendorDto;

          // Act
          var response = UpdateVendorProductOffer(newVendorDto);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GeneratePDFReceiptTest()
        {
          // Act
          var response = GeneratePDFReceipt();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateOrderProductsDisplayNameTest()
        {
          // Act
          var response = UpdateOrderProductsDisplayName();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetPaginatedVendorsTest()
        {
          // Arrange
          VendorsFilterModel vendorsFilterModel;

          // Act
          var response = GetPaginatedVendors(vendorsFilterModel);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetAllPlatformUsersbyVendorIdTest()
        {
          // Arrange
          AllPlatformUsersFilterModel platformuserFilteringModel;
          string vendorId;

          // Act
          var response = GetAllPlatformUsersbyVendorId(platformuserFilteringModel, vendorId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void GetAllUsersv2Test()
        {
          // Act
          var response = GetAllUsersv2();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void LoadConvertedScoresTest()
        {
          // Arrange
          ModuleConversionTableDto moduleConversionTable;

          // Act
          var response = LoadConvertedScores(moduleConversionTable);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVendorDisplayNameTest()
        {
          // Arrange
          string vendorId;

          // Act
          var response = UpdateVendorDisplayName(vendorId);

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }

        [Fact]
        public void UpdateVendorTest()
        {
          // Act
          var response = UpdateVendor();

          // Assert
          Assert.NotNull(response);
          Assert.Equal(StatusCodes.Status400BadRequest, response.StatusCode);
          Assert.NotNull(response.Value);
        }


    }
}


