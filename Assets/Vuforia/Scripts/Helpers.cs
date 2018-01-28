using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
	public static T getJsonArray<T>(string json)
	{
		return JsonUtility.FromJson<T> (json);
		//Wrapper wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
		//return wrapper;
	}

	[System.Serializable]
	private class Wrapper<T>
	{
		public T[] array;
	}
}


[System.Serializable]
public class Object
{
	public string ID;
	public string name;
	public string description;
}
[System.Serializable]
public class ResponseList
{
	public List<Object> objects;
	public int limit;
	public int offset;
	public int total;
}
[System.Serializable]
public class RootObject
{
	public int status;
	public object error;
	public Object response;
}