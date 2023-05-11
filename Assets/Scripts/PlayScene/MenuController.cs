using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // ���j���[�̂ǂ���I�����Ă��邩�̔���
    public static int menuNum;
    // �I�����Ă��郁�j���[�ɂ���ĉ�N�̈ʒu�ύX�p�x�N�^�[
    Vector2[] playerPos = new Vector2[4];
    // �L�[���͂ɂ���ăA�N�e�B�u���Ǘ����邽�߂�SerializeField
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject menuBack;

    // �A�j���[�V�����p�ϐ�
    int menuNumAnim;
    // �A�j���[�V�������󂯎��
    [SerializeField]
    Animator AnimSelect;
    [SerializeField]
    Animator AnimOpen;
    [SerializeField]
    Animator menuExp;

    // Start is called before the first frame update
    void Start()
    {
        // �ϐ��̏�����
        menuNum = 1;
        playerPos[0] = new Vector2(0.0f, 1.88f);
        playerPos[1] = new Vector2(0.0f, 0.701f);
        playerPos[2] = new Vector2(0.0f, -0.203f);
        playerPos[3] = new Vector2(0.0f, -1.806f);

        menuNumAnim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ���݂̃A�j���[�V�����̃p�����[�^�̒l���󂯎��
        menuNumAnim = AnimSelect.GetInteger("menuNum");

        // �e�ϐ��̃N�����v�@���̓��j���[�̑I���ł��鐔
        menuNum = Mathf.Clamp(menuNum, 1, 4);
        menuNumAnim = Mathf.Clamp(menuNum, 1, 4);

        // �I�����Ă��郁�j���[�ɂ���ĉ�N�̈ʒu�ύX
        this.transform.position = playerPos[menuNum -1];

        // �l�̉��Z
        if(Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            menuNum--;
            menuNumAnim--;
        }
        // �l�̌��Z
        if (Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            menuNum++;
            menuNumAnim++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (menuNum == 3)
            {
                MenuManager.menuFlag = false;
                // �Z���N�g�V�[����ǂݍ���
                // ���j���[�t���O�����Z�b�g�����j���[���\����
                menuBack.SetActive(false);

                SceneManager.LoadScene("SelectScene");
            }
            if (menuNum == 4)
            {
                // �Q�[���I��
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif            
            }
            // ���j���[�̑I������ԏ�ɖ߂�
            menuNum = 1;
            AnimOpen.SetBool("menuFlagAnim", MenuManager.menuFlag);
            menuExp.SetBool("menuFlagAnim", MenuManager.menuFlag);

        }
        // �A�j���[�V�����̃p�����[�^�[��ݒ肷��
        AnimSelect.SetInteger("menuNum", menuNumAnim);
    }
}
