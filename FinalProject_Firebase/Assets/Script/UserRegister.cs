using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class UserRegister : MonoBehaviour
{
    FirebaseDatabase database;
    DatabaseReference reference;

    [SerializeField] InputField NickNameInput;
    [SerializeField] Text checkText;

    void Start()
    {
        database = FirebaseDatabase.GetInstance(
            "https://onlinegame-finalproject-default-rtdb.asia-southeast1.firebasedatabase.app/"
        );

        reference = database.RootReference;
    }

    public void Register()
    {
        string nickName = NickNameInput.text;

        if (string.IsNullOrEmpty(nickName))
        {
            checkText.text = "닉네임을 입력하세요.";
            return;
        }

        CreateUser(nickName);
    }

    void CreateUser(string nickName)
    {
        DatabaseReference newUserRef =
            reference.Child("UserInfo").Push();

        string userKey = newUserRef.Key;

        UserData userData = new UserData(nickName);

        string json = JsonUtility.ToJson(userData);

        newUserRef.SetRawJsonValueAsync(json);

        PlayerPrefs.SetString("UserKey", userKey);
        PlayerPrefs.SetString("UserNickName", nickName);

        checkText.text = "회원가입 성공!";
    }
}
