using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // �ŧi�ܼ�
    public GameObject foodPrefab;

    // �I���禡
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Tail"))
        {
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.CompareTag("Food"))
        {
            Destroy(coll.gameObject);
        }

        // �ͦ��s������
        Vector3 pos = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
        Instantiate(foodPrefab, pos, Quaternion.identity);
    }

    #region �򥻳g�Y�D��������
    /*�o�ӵ{���X�|�b�����M���ڸI���ɧR����H�C�b�I����A���|�ͦ��@�ӷs����������C�s����������|�b�H����m�ͦ��C�n�ϥγo�ӵ{���X�A�ݭn�N����[�쭹������W�A�æb�ݩʭ��O���]�m�����w�m���C
    �ݭn�`�N���O�A�o�ǵ{���X�Ȭ��򥻥ܨҡA�i�H�ھڻݭn�i��ק�M�X�i�A�Ҧp�K�[��ê���Χ�h�C���W�h�C�P�ɡA�o�ǵ{���X�]���]�A�C���������]�p�A�ݭn�ϥ� Unity �����ӳЫؾA�������M�C���귽�C*/
    #endregion
}
