namespace ApplicationManagement.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class QuestionTypes
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/questionTypes";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/questionTypes/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/questionTypes/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/questionTypes/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/questionTypes/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/questionTypes";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/questionTypes/batch";
    }

    public static class Programs
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/programs";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/programs/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/programs/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/programs/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/programs/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/programs";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/programs/batch";
    }

    public static class ProgramCustomQuestions
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/programCustomQuestions";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/programCustomQuestions/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/programCustomQuestions/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/programCustomQuestions/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/programCustomQuestions/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/programCustomQuestions";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/programCustomQuestions/batch";
    }

    public static class ProgramApplicantPersonalInformations
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/programApplicantPersonalInformations/batch";
    }

    public static class ProgramApplicantCustomQuestionResponses
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/programApplicantCustomQuestionResponses/batch";
    }

    public static class MultipleChoiceQuestions
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/multipleChoiceQuestions/batch";
    }

    public static class DropdownChoiceQuestions
    {
        public static string GetList(string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions";
        public static string GetAll(string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions/all";
        public static string GetRecord(Guid id, string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions/{id}";
        public static string Delete(Guid id, string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions/{id}";
        public static string Put(Guid id, string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions/{id}";
        public static string Create(string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions";
        public static string CreateBatch(string version = "v1") => $"{Base}/{version}/dropdownChoiceQuestions/batch";
    }
}
