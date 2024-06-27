using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider enemyHealth;
    public TextMeshProUGUI playerHPtext;
    public TextMeshProUGUI playerMPtext;
    public TextMeshProUGUI playerShieldtext;

    public void SetupDragon(Dragon player)
    {
        playerHPtext.text = (player.maxHP.ToString());
        playerHPtext.text = (player.currentHP.ToString());
        playerMPtext.text = player.GetCurrentMana().ToString();


        playerShieldtext.text = (player.currentShield.ToString());
    }
    public void SetupEnemy(Knight enemy)
    {
        enemyHealth.maxValue = enemy.maxHealth;
        enemyHealth.value = enemy.currentHealth;
    }
    public void UpdatePlayerHP(int hp)
    {
        playerHPtext.SetText(hp.ToString());
    }

    public void UpdatePlayerMP(int mp)
    {
        if (mp > 0)
        {
            playerMPtext.SetText("" +
            "                                                                                                    \r" +
            "\n                                                              ZY                                    \r" +
            "\n                                                          ZZYZZZ                                    \r" +
            "\n                                                         Z     Z                                    \r" +
            "\n                                                      ZZ       Z                                    \r" +
            "\n                                                   Z           Z Z                                  \r" +
            "\n                                                 Z             Z Z                                  \r" +
            "\n                                              Z                ZZ                                   \r" +
            "\n                                            Z       ZVUWVZ     Z Z                                  \r" +
            "\n                                         ZZ         WSUWUX     Z Y                                  \r" +
            "\n                                       Z            UTWTVTX     ZZ                                  \r" +
            "\n                                    ZZ  Z          ZWUSPSTVY    YY                                  \r" +
            "\n                                 ZZYZ              ZYUSQSWYXZ   ZX                                  \r" +
            "\n                               ZZZ Z                ZYVSQVSVY   ZY                                  \r" +
            "\n                             ZYYZZ                 YVVZRRUVUX   ZZ                                  \r" +
            "\n                           ZXZZ                     VWZWTRUVW   ZY                                  \r" +
            "\n                         ZZ Z                       XUWWTTTY     X                                  \r" +
            "\n                       ZZ                          YUWXVQRVZ     V                                  \r" +
            "\n                    ZZZ                            XTRVUPUW      W                                  \r" +
            "\n                  ZXXZZZ                        XWWTSTSPUZZZ     V                                  \r" +
            "\n                ZYYZ ZZZ                     VVPWYXTRRWVSVX      UZ                                 \r" +
            "\n             Z WXZZ YZ                    YUQQQQQTVSWVTYZ        VY                                 \r" +
            "\n            ZWXZY ZZ                  WXVURRQSUTWUTRWZ           YV                                 \r" +
            "\n          ZXWYXYZZ                 WRQQSUORUUTSTVU              YYSZ                                \r" +
            "\n         YWZ VYZ                 YUQQRNNSURQTSYV                 ZVVY                               \r" +
            "\n       ZWXZ                     ZRSUPQSSVPSX                         YVVZ                           \r" +
            "\n     ZXVZ Z                   ZYVRQSWTTV                                YUVY                        \r" +
            "\n    ZXY                      WQRQOOPQU                    Z                ZXUY                     \r" +
            "\n  ZXVZ                      TQPQSRRNV                  ZTQTXZ                  XX                   \r" +
            "\n  ZWU                      POQNSQOQV             XUQQPXVTNLOKQUX                 YUU                \r" +
            "\n   YUY                    YSQOSRQV             UOQKNPNORRPQONNRRPPW               ZXY               \r" +
            "\n   ZWU                  ZVYTNROQU            OOJOMUNRTPOQPNQPRNNSQOR                YZ              \r" +
            "\n   ZZVWZ                UQNQPOOV            OJJQRPOKTWWW VNNMNNPNQQVQT              ZV              \r" +
            "\n    ZXUZ               XQQQOQOV            ZSJKHMKZ          ZPPRQPNMPX              XX             \r" +
            "\n     ZVV               SQOOOTZ             YYQKLKK              XVQPLOW               XY            \r" +
            "\n      XSV              SYWRUV                UZSO              UNRRROOV                X            \r" +
            "\n       WTWZ           SW XPPS                                  RMOTPPRU                YY           \r" +
            "\n       YSUU          ZRRQQNOV                                   WPSQPSQV                XZ          \r" +
            "\n        YRTZ         YPQOLNLX                                   PNPPQQPZ                 XZ         \r" +
            "\n         YQX          TMPOMSSUWW                               QSRSPNQW                   Z       \r" +
            "\n          UR          TNQQPSMPY                                YRSQSSWWZ                  Z        \r" +
            "\n          QU          TQNMONOZ                               WTNVOPQPV Z                ZZ         \r" +
            "\n           VRZ        YZRLMLMLP                              ZRRUQRTQQV                 XY          \r" +
            "\n            UP          VNMPKLOMQZ                           RQTTPUYSTZ                XX           \r" +
            "\n            XRT          QPNPMOMMO                          YSQSQQSVRW                YWY           \r" +
            "\n             UO           TMLNLLNKKU                        ZXZVROTTRTY               ZXY            \r" +
            "\n              RM           QSJJPLNP                ZLTTSTQPSUTNPQQTQS                TZ             \r" +
            "\n              XRR            UPSOUPYSPOQRTURTUTSXVXWSVTOQPPRQTSSSSRS                UZ              \r" +
            "\n               WPU           VPRSVUVSRNQQNLOLQPRTIOKMQPMOOPOOPPT SRZ               XY               \r" +
            "\n                QQW           WVYYTUQKKNSPMSNLPPSNPONNORTPQSUXYZ                   T                \r" +
            "\n                ZQUY           ZUYZXVVVSOSPMLLOWTPRLNQQOOV                       YW                 \r" +
            "\n                 XOS                                                            XV                  \r" +
            "\n                  SQV                                                          ZS                   \r" +
            "\n                  SRX                                                         TZ                   \r" +
            "\n                  YOSV                                                       SX                    \r" +
            "\n                  VSVX                                                       UT                     \r" +
            "\n                   YYYZYXWXVXXYXYYZXYZYZYYXXYYXXZXYXXYZXXYXXYZZZZZZZZZZZXYXYZYZ    ");
        }
        else
        {
            playerMPtext.SetText("");
        }
    }

    public void UpdateEnemyHP(int hp)
    {
        enemyHealth.value = hp;
    }
    public void UpdateShield(int shield)
    {
        if (!playerShieldtext.IsActive()) {
            playerShieldtext.IsActive();
        }
        playerShieldtext.text = (shield.ToString());
    }
}
