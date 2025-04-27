namespace agenda_api.ViewModels;

public class ResultViewModel<T> where T : class {
	public List<T> Data { get; private set; } = [];
	public List<string> Errors { get; private set; } = [];

	public ResultViewModel(T data, List<string> errors) {
		Data.Add(data);
		Errors = errors;
	}

	public ResultViewModel(List<T> data, List<string> errors) {
		Data = data;
		Errors = errors;
	}

	public ResultViewModel(T data, string error) {
		Data.Add(data);
		Errors.Add(error);
	}

	public ResultViewModel(T data) {
		Data.Add(data);
	}

	public ResultViewModel(List<string> errors){
		Errors = errors;
	}

	public ResultViewModel(string error) {
		Errors.Add(error);
	}

	public ResultViewModel(List<T> data) {
		Data = data;
	}
}