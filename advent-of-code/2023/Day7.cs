using System.Runtime.CompilerServices;

namespace aoc._2023
{
    internal static class Day7
    {
        private static readonly string TestInput = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";
        private static readonly string Input = "5J984 114\r\n766KQ 685\r\n6KQK6 169\r\n2A663 361\r\n7T849 916\r\nAKKQA 144\r\n99KKK 430\r\n787J8 587\r\n7JJ77 757\r\n5AA9A 561\r\nA7T4J 166\r\nQ9A7J 843\r\n32QT5 11\r\n88555 936\r\n99899 421\r\nK88KK 784\r\nAA222 806\r\n6A5T7 911\r\n5A53A 896\r\n8J544 827\r\n99952 377\r\n9JQ44 950\r\nKQKK3 670\r\n963J5 490\r\n7JJ99 91\r\nQ6QQJ 571\r\n26622 866\r\n68J8T 395\r\nTQK56 106\r\n5JJK9 285\r\nA67AA 197\r\n99949 645\r\n56422 955\r\nA94AJ 636\r\n8888K 729\r\nK5993 584\r\n777J8 445\r\n2T42T 514\r\nJTK7J 7\r\nTA5TT 18\r\n96J29 249\r\n44254 801\r\n44579 130\r\nQQQAA 903\r\nA3839 159\r\nAATAA 511\r\n6K59A 347\r\nQ7968 27\r\n63636 315\r\n28282 136\r\n7J44Q 603\r\nT6JT6 538\r\n5KA3Q 692\r\n87Q88 787\r\n99599 574\r\nT9AAJ 299\r\nA737K 663\r\n7K539 80\r\n555QQ 240\r\n5AAAK 897\r\n233AA 294\r\n2T233 793\r\nJ5559 357\r\nT7AJ7 569\r\n72729 807\r\nKKQKK 163\r\nK6KK6 997\r\n254K5 34\r\nJ7TTK 155\r\n62Q8T 975\r\n3AAQK 621\r\n6QJJQ 500\r\nAK736 276\r\nKK666 840\r\nQ7Q57 260\r\n836T6 859\r\n2K22K 5\r\n97589 216\r\nATA2A 783\r\n5JJ5J 864\r\n6QJJ6 158\r\n59K9K 323\r\nKKK77 893\r\n33AAA 922\r\nQ6A3K 669\r\n6238K 333\r\nQAQ46 283\r\n954QK 268\r\n634TA 471\r\n22823 393\r\nA8TQ8 749\r\n33T3T 727\r\n5AA77 288\r\n77KQ7 622\r\n587KK 42\r\nAAAKA 736\r\nT7J77 939\r\n89A5T 881\r\nA494K 467\r\n35T4A 641\r\nQT85K 937\r\n7J5T7 337\r\nQQ4KA 989\r\n9TA46 492\r\n7KKKK 224\r\nJQ478 431\r\n69665 609\r\n32Q2Q 967\r\nQQ9QJ 977\r\nTAJQK 710\r\n94448 200\r\nJ4422 678\r\n2A822 340\r\nA72K7 179\r\nJ8JJ6 290\r\n8KAK6 549\r\n644J6 659\r\n444K9 612\r\n3KA97 402\r\nJ3333 928\r\n96855 261\r\nQ3K43 779\r\n33494 303\r\n4T297 687\r\nJ998A 349\r\nT999T 860\r\n79246 341\r\n97J8J 990\r\n2J954 448\r\n338A8 281\r\nK9999 724\r\n6666A 327\r\nJJJ8J 704\r\nKK5J5 942\r\n328T5 573\r\nTT6T4 699\r\nJQQQQ 961\r\nQ37TQ 354\r\n6668K 608\r\n82222 368\r\n4449J 650\r\nTA6AQ 172\r\nT5J29 383\r\n52555 24\r\nA98KA 175\r\nA2J63 65\r\n45594 149\r\n9J784 930\r\nKJKTK 350\r\n44484 839\r\n56585 273\r\nJQQ46 945\r\n8JKKK 400\r\nKK4T4 617\r\n5K553 1\r\n2227T 225\r\nT3TTK 853\r\n8TT88 404\r\n8TJ64 270\r\nA927K 594\r\nA79A7 589\r\nJT499 957\r\nQ88Q8 730\r\n2A2TQ 913\r\nAQT58 87\r\n444AQ 737\r\n7777J 452\r\nTTT39 8\r\nJAAAA 243\r\n43533 102\r\n53333 598\r\n6QQQ6 711\r\n33JTT 308\r\n98QQJ 124\r\n66644 300\r\n64K36 46\r\nJT8K9 921\r\n35AA3 848\r\n2QQ72 161\r\n2A4QQ 90\r\n6J777 52\r\n9T299 75\r\nJJ999 204\r\n7977K 499\r\n32357 742\r\nJQTKT 810\r\n89998 81\r\n82QTQ 734\r\n778AQ 522\r\nT992A 847\r\nTT85T 138\r\nK9KQK 841\r\nQ6654 367\r\n333JQ 122\r\nQQ655 219\r\n76699 966\r\n4J784 66\r\n7AJ84 557\r\nJ363T 548\r\n23487 732\r\n6635A 604\r\n22J92 223\r\n44494 983\r\nJTTKK 214\r\n993AA 61\r\n35462 147\r\nT6666 94\r\n5QQ22 946\r\n58QQ5 607\r\n569K8 520\r\n97J7A 940\r\n9955K 356\r\n99J9A 797\r\n57566 863\r\n77KK7 447\r\n6K999 504\r\nQQ6A6 111\r\n49979 712\r\nQ888T 882\r\n45875 611\r\nQ8A9A 735\r\n6Q2QQ 648\r\n44545 370\r\n4A994 177\r\n5KQKK 86\r\nTT9TT 241\r\nTQQ4T 145\r\n2366J 705\r\nJ5388 796\r\n555TK 317\r\nKK822 959\r\nT44JA 614\r\n2Q762 295\r\n33539 570\r\nAA7J7 215\r\n22277 314\r\n366JA 129\r\n58888 17\r\n8A8A8 302\r\n54499 919\r\n884JJ 412\r\n5Q554 150\r\nAT96K 649\r\n27K2K 190\r\n4J2K7 776\r\n99QA7 886\r\nA4558 760\r\nTT3TT 850\r\n92522 183\r\n33777 460\r\n99246 802\r\n45995 373\r\n66866 618\r\nKA77K 496\r\n66QQ8 221\r\n55755 780\r\n658KQ 994\r\n78T77 910\r\nK55K5 951\r\nT9KA7 728\r\nK6923 97\r\nT7977 189\r\n7AAAA 275\r\nJ9666 255\r\n66736 918\r\n339Q9 803\r\n34333 599\r\nJ9599 157\r\nJATTA 267\r\nQ336K 312\r\nJ6598 40\r\nQ8Q8J 537\r\nT2TTT 76\r\n7T7T7 502\r\n24222 682\r\n55K5J 865\r\n29692 743\r\n99276 543\r\n5KQQQ 938\r\n7T78K 889\r\n6577Q 310\r\n645KA 78\r\n68222 854\r\n33K25 998\r\n66K66 207\r\n59939 510\r\n7858J 521\r\nA9947 55\r\nT2J3Q 374\r\n9QJ39 898\r\nAATA8 733\r\nAT38T 700\r\nK7Q29 384\r\n26JQK 19\r\nJ5333 263\r\n52K95 525\r\nQQAQT 459\r\n88868 808\r\n9QJ55 233\r\n3KAA2 651\r\n7633A 953\r\n45542 126\r\n96T88 494\r\nKKK95 182\r\n3TQ56 572\r\n8QTTT 747\r\n5TTT3 428\r\n445J5 164\r\n5788T 399\r\n7KQKQ 653\r\nA5688 826\r\nT3JTT 51\r\n7JJ79 713\r\n355AT 782\r\nTQJKQ 388\r\nKKT9K 409\r\n22332 465\r\nA6566 824\r\nAJA99 2\r\n654J6 43\r\n55T45 948\r\n7989T 697\r\n2249J 206\r\n33336 991\r\n8932A 472\r\n5A6T6 245\r\n2T2TT 429\r\n9JQJ9 242\r\nJ7JAA 746\r\n78TQ4 809\r\n99494 563\r\n28JA3 547\r\nA3A9A 389\r\n9QQTT 696\r\n73T89 390\r\n825JQ 186\r\n737Q3 654\r\nK33T3 481\r\nQQ8QQ 418\r\n66A5A 201\r\n5Q327 965\r\n23233 970\r\nT33TT 26\r\nT45JJ 420\r\n88684 32\r\nKT696 758\r\nA3A8A 324\r\nJTA78 518\r\nJ3838 539\r\nKJAAA 606\r\n92999 237\r\n39933 22\r\n922KA 365\r\nT44T4 871\r\n49J3T 680\r\n66688 716\r\n8Q68Q 721\r\n6676J 844\r\n2K426 986\r\nQ6J3K 952\r\n96A64 104\r\n84448 907\r\nA9A76 888\r\nTTT4T 887\r\n44TKT 805\r\n22QQ2 123\r\n78293 208\r\n58T59 634\r\n92TKQ 773\r\nJ9J9J 184\r\nJQQQK 218\r\n5T88T 885\r\nT6TT9 980\r\n22J22 154\r\n7Q777 364\r\n47474 909\r\nAAAA9 979\r\n75655 292\r\nTJ942 693\r\nQ4AT4 9\r\nT8J85 745\r\nJJK7K 777\r\n76T8A 309\r\n88A7A 332\r\n74Q3J 656\r\n56TJ5 211\r\n23K72 475\r\nQK8K8 318\r\n2922Q 264\r\nT4QQ9 666\r\n97999 676\r\nK83T8 173\r\n552J7 553\r\n6J7KA 162\r\nATA7T 778\r\nAA94K 681\r\n83K63 414\r\nK77K3 441\r\n544JJ 305\r\nJ2252 625\r\n46JJ8 25\r\n4282A 466\r\n66468 630\r\n98Q5Q 739\r\n62346 371\r\n4K89Q 926\r\n8222K 462\r\n4T33T 794\r\n82T38 534\r\n5A55A 973\r\nAAKKJ 535\r\n6A342 505\r\nTQTTT 588\r\nKA8A4 256\r\nJ2454 116\r\n89K5J 723\r\n43855 199\r\n38T47 140\r\nJ9AA2 551\r\n24242 422\r\nT2KTK 963\r\n5493Q 532\r\n67446 647\r\nJ5QQQ 133\r\nKK6KK 748\r\nJTTA8 6\r\n5A78A 644\r\n59552 29\r\n7JAAA 449\r\n6QK43 686\r\n8288K 668\r\n777KJ 917\r\n87656 869\r\n55322 901\r\n5AA5A 544\r\n48888 222\r\n4Q794 101\r\n97979 360\r\n5J37Q 93\r\n2QKK9 497\r\n52525 134\r\n7847K 923\r\nTAJTT 879\r\n4ATQK 64\r\n53Q22 440\r\nK843Q 195\r\n555T5 286\r\nJQQAA 643\r\nJQQJQ 506\r\nJ329J 329\r\n72222 981\r\n79J99 877\r\n9QQ97 236\r\nQJ676 593\r\nTTJJT 446\r\nKQAKK 394\r\n68886 738\r\n7238T 799\r\nK32K3 258\r\n29442 673\r\n8Q87Q 212\r\n6J965 444\r\nA7J45 454\r\nJ99KK 637\r\n42AA2 105\r\nJ6556 478\r\n33ATJ 473\r\n26A6Q 517\r\nQJQJ5 932\r\nK45TT 425\r\n894TK 944\r\n99A97 411\r\nA8557 583\r\nT2T99 398\r\nK43Q2 397\r\nK3TT3 72\r\nQQQQ6 278\r\nQ5KK5 450\r\nTT222 660\r\nTTT7T 185\r\n4JTQJ 56\r\n77A77 375\r\n78888 345\r\n7AQT2 905\r\n84A58 899\r\n4KQ28 230\r\nT8529 16\r\n42424 894\r\n99922 451\r\nQ9QQ2 352\r\n32299 403\r\n2K465 396\r\n68Q3T 313\r\n4AJ44 635\r\n993J3 108\r\n27772 845\r\nJAA3A 818\r\n43242 468\r\nJQ52J 718\r\n4K3KK 702\r\n22KK3 493\r\nQ5QKA 82\r\n22666 413\r\nJ3Q29 120\r\n694K3 876\r\n888Q8 229\r\n2AQQ9 271\r\n843Q9 890\r\n6476J 250\r\n82T49 457\r\nAJ2K2 988\r\nQ678T 674\r\nQ4T9T 792\r\n25274 519\r\n555TQ 714\r\n52858 852\r\n579JJ 355\r\nJT664 771\r\n68JQT 559\r\nK4KKK 455\r\nQAA9Q 321\r\n2T2JA 836\r\nK68J2 706\r\nJTTT5 69\r\nTQ58T 580\r\nATKT7 464\r\n7J977 765\r\nT4487 536\r\n8K382 672\r\n54533 284\r\n92A99 392\r\nK995J 344\r\n78737 67\r\nA5623 319\r\n389QA 307\r\nJ4244 210\r\n7799J 156\r\n3A44A 89\r\n44458 825\r\n263K5 213\r\nTTTJT 228\r\n33833 862\r\n333Q9 616\r\n8J888 639\r\n4J446 372\r\n8Q423 193\r\n4T55T 57\r\n8949J 731\r\nKK5K5 331\r\nQ99AQ 279\r\n6T262 73\r\nA725T 53\r\n59555 4\r\n2A27A 165\r\n3A72A 23\r\n2K5A5 358\r\nK98TA 822\r\n55554 100\r\n777T7 474\r\nQJAKK 369\r\n352J5 586\r\n8A639 615\r\n63Q3J 655\r\n26QQJ 829\r\nTTT66 417\r\n6QA8A 949\r\n47A78 31\r\n47J74 437\r\n86342 419\r\n36T59 508\r\n6Q8K6 891\r\n646AA 987\r\n46666 342\r\n85QK8 320\r\n98588 289\r\n96969 251\r\nK5QQK 85\r\nJ7775 755\r\n88484 435\r\n4JAQT 426\r\n4J5J6 816\r\n522Q8 741\r\n83QA5 868\r\n3J6J3 984\r\n2J2QQ 15\r\n44644 247\r\n6AA6A 912\r\n4922A 96\r\nTTAAA 160\r\nA9JTJ 433\r\nJ5799 59\r\nK7K72 453\r\nTTJ9T 873\r\nJ844T 821\r\n45343 744\r\n555A5 385\r\nT724J 812\r\n46TT7 830\r\nKQJ29 768\r\n3K33K 343\r\nJ977K 381\r\n999J2 664\r\n4863K 92\r\n48Q6K 434\r\n44J4J 971\r\n99Q99 458\r\n89898 432\r\n78772 37\r\n753J2 756\r\n7K75A 143\r\n45556 578\r\n4Q6AT 287\r\nK35JK 992\r\n999KK 338\r\nQ6KQQ 856\r\nQ2264 469\r\n47TKA 107\r\n85559 280\r\n88777 239\r\n45TTJ 766\r\nQQ988 180\r\n7A3A3 456\r\n23397 556\r\n7TJK2 470\r\n6T6T6 366\r\nA585J 391\r\n2K2Q4 914\r\nAA6AJ 135\r\nA4AA4 560\r\n4TK48 823\r\n34944 566\r\n33977 226\r\nT8TTJ 833\r\n777K7 170\r\n9J388 683\r\n95955 304\r\nTTQQJ 205\r\n2T6A2 501\r\n52424 690\r\nJAT2J 512\r\n95566 769\r\nTA3KJ 633\r\n55A45 487\r\nAA333 209\r\nA5K29 601\r\n8AA8A 3\r\n27AK6 610\r\n44445 786\r\n2K44Q 137\r\n9KA59 359\r\nTQ488 118\r\n36886 934\r\nJ7KJ5 993\r\n77787 410\r\nA777A 44\r\n76732 626\r\n3K3KT 838\r\nKK46K 513\r\nJ3633 781\r\nJ3733 555\r\n99399 804\r\n9K6T4 552\r\n9K9QT 171\r\n5TT59 408\r\n8T37J 929\r\n2864K 12\r\n55333 259\r\n4485K 662\r\nQ7QQQ 336\r\nTTTTA 638\r\nQ3T33 947\r\n98993 296\r\nJ4334 642\r\n3J999 139\r\n3QQ44 60\r\n43K92 597\r\n56733 695\r\n22Q39 117\r\n4J2J8 775\r\n3QQQ3 217\r\n66558 795\r\nAA2K2 762\r\n22JJ2 531\r\n85742 851\r\n87QTK 20\r\n8JT6T 187\r\n244Q4 188\r\n2TT49 335\r\n44K44 152\r\n883A9 585\r\nT6J32 376\r\n5JK2J 148\r\nJ8J38 379\r\n36KT2 567\r\nJT662 602\r\nJQ5KT 83\r\n2222Q 627\r\nQ699Q 763\r\n9Q24Q 798\r\nTJ7A5 576\r\n8958Q 109\r\n2T73T 322\r\nQ7493 88\r\n3J33J 872\r\n9J8J8 722\r\nJ7A2K 191\r\n55758 119\r\nQ6466 326\r\n79352 115\r\n3T3K6 252\r\n464Q4 995\r\n356J8 740\r\nJ9JQT 540\r\n96233 554\r\n92AJ5 79\r\n42228 709\r\n4J84K 346\r\n74A4A 178\r\n89229 277\r\n2T6J2 565\r\nQ9Q99 49\r\nT33Q2 45\r\n9Q9A3 985\r\n63969 541\r\nQ44QQ 524\r\nA9999 935\r\nATTTA 815\r\nQ75JQ 238\r\n4787J 596\r\nQQ7Q7 564\r\n5J7T3 386\r\n98T99 382\r\nT8J82 884\r\n64464 297\r\nTTT2J 753\r\n699J9 623\r\n5J755 167\r\n333A3 751\r\nJJAAA 867\r\nA8A58 969\r\nTKKKK 232\r\nTT57T 1000\r\nJJJJJ 35\r\nQ8Q2Q 906\r\n44A44 363\r\n38A2K 203\r\nJ5KAQ 691\r\nK2KK6 328\r\n6AQQQ 878\r\n7K5TA 999\r\nAQ272 95\r\n86JAT 298\r\n7TATQ 125\r\n3K382 439\r\n3TT99 509\r\nTKJJ2 99\r\n6J4K2 752\r\n28687 244\r\nA243A 689\r\nQQQA8 168\r\n6AK5Q 407\r\n3J739 870\r\nT565T 933\r\nQTAAQ 351\r\n539K8 311\r\n77T9Q 819\r\n889T5 98\r\n55T9J 924\r\n2Q5J3 968\r\nKQ32Q 631\r\n5K225 142\r\n57788 715\r\nAQQAA 198\r\nJQ24K 77\r\n78788 174\r\n2293J 488\r\n77772 958\r\n57995 849\r\nKT87T 754\r\nJ895J 141\r\nT36KA 254\r\nAAA2A 334\r\n3A999 58\r\nTJ2JT 416\r\nK2227 545\r\n5J3T5 550\r\n64964 925\r\n63T69 41\r\n2TQQ4 837\r\nKJA87 533\r\n3778J 528\r\nJQJ9A 21\r\n42J36 227\r\n529K7 196\r\nQT8K3 832\r\nJ8QQ5 84\r\n8K6J4 976\r\nJ8JQ8 231\r\n5AJ8A 591\r\nQ9T66 498\r\n7557J 70\r\nT48JT 476\r\n75552 632\r\nAAAQA 282\r\n75725 401\r\nT996Q 405\r\n467T8 39\r\nKQKQK 620\r\n4Q237 265\r\nA9JAA 892\r\nA3K7Q 772\r\n3Q6J5 132\r\n634J3 904\r\nQ6255 272\r\n8A9A8 13\r\nQQQQ5 590\r\n56566 112\r\n66477 701\r\n56QJQ 640\r\nQAK84 875\r\n4KQQT 68\r\n63QTQ 526\r\nK425T 71\r\n888KK 362\r\nJ984K 489\r\n6666J 931\r\n33732 770\r\n7227J 482\r\nKK5K2 895\r\nA2588 707\r\n58333 248\r\n3928K 253\r\nKKTQK 131\r\n94A77 121\r\nQ8688 527\r\nJQK99 339\r\nKT335 491\r\n2J22A 387\r\n32977 717\r\n6A6A8 834\r\n2K2KK 54\r\nA997A 726\r\n6J66J 652\r\n27979 151\r\nA66T6 235\r\n4J444 694\r\n4A8K4 579\r\nJ6AJ4 28\r\n244QA 74\r\n366KJ 220\r\n7T3T3 814\r\n49494 954\r\n8866Q 811\r\nT3K42 613\r\n7Q878 257\r\n6793Q 813\r\nK993K 262\r\n2544A 306\r\n9J999 62\r\n4TT98 47\r\n22225 790\r\nJATKA 855\r\n43726 629\r\n6T556 820\r\nAJT2T 523\r\n2227A 978\r\n6QQJ6 427\r\nA4A7A 529\r\n88882 63\r\n88T88 791\r\n555JA 677\r\nJ8J88 708\r\nKK9KK 516\r\n45455 831\r\nT54TT 463\r\nJ3T66 661\r\n535J9 10\r\n3A2AA 671\r\n2J22T 764\r\nJQ7KK 725\r\n33337 720\r\nATT3J 192\r\nQ7QTQ 153\r\n27A3Q 767\r\nJ63JA 423\r\nKT453 293\r\n27TTJ 658\r\nK7Q54 477\r\n64Q46 436\r\n984TQ 679\r\nAAJ54 817\r\n4K424 858\r\n55T7Q 575\r\n79377 274\r\n4JQ54 194\r\n434Q2 181\r\nAJQ8K 128\r\n2TT92 595\r\n37J7T 605\r\nQQ8Q4 920\r\n4999T 484\r\nK4K7K 880\r\n9222K 443\r\n77767 646\r\nAJJAJ 964\r\nA782J 785\r\n35A7K 789\r\nQJ42J 703\r\n4J243 14\r\nJTAAA 835\r\nA7425 479\r\nA5TTA 546\r\n9Q298 562\r\n53935 582\r\n6643Q 406\r\n4TJJT 507\r\n26666 234\r\nQQ5Q2 480\r\n557AA 624\r\nTQ35Q 495\r\n72767 38\r\nT95A4 146\r\n88KA5 996\r\n35735 592\r\nKJJKK 577\r\n453K6 883\r\nAA4AA 542\r\n67895 530\r\nKKKKJ 684\r\n6469Q 316\r\n648J5 842\r\n74747 483\r\n3J63A 874\r\n4K5TA 960\r\n65555 915\r\n26K2K 759\r\nTT933 941\r\nAA2J6 667\r\n33344 675\r\nKKKAA 788\r\n55656 600\r\n634T7 36\r\n7TTQJ 438\r\nTJ444 902\r\n2266J 291\r\n77775 325\r\n66JQ6 378\r\n69669 461\r\n27K86 568\r\n493AT 688\r\n5JJ5A 503\r\nT5TTT 956\r\nTJT73 982\r\n8J272 380\r\nKT9TT 103\r\n463A4 48\r\n66TTK 719\r\n27QJJ 246\r\nJQ5Q5 330\r\nA39T2 900\r\nQQ33T 800\r\n5JJ55 774\r\n38526 424\r\n77774 828\r\nA547T 761\r\n5449J 110\r\nKKAA4 301\r\n6T549 176\r\n39AA3 972\r\n55977 628\r\n727A4 127\r\n4J247 665\r\n97777 202\r\nK5Q38 353\r\n5J555 558\r\nKA587 943\r\n77667 908\r\nKJ7T4 348\r\n69667 974\r\n3JT38 750\r\n33AAQ 415\r\nTJ22T 962\r\n76876 927\r\n75722 515\r\nA3822 581\r\n7Q44Q 857\r\nQQQAQ 33\r\n9AA9A 266\r\nQ7QJ2 619\r\nJ7K72 846\r\n7A6A6 861\r\n666Q6 657\r\n333JA 113\r\n7243A 442\r\n2KT94 50\r\n8898T 485\r\n3AJ53 30\r\n42J22 698\r\n585J6 269\r\nQT527 486";
        private static List<string> _lines = Utilities.StringToLines(Input);

        internal static int Part1()
        {
            string cardOrder = "23456789TJQKA";
            var handList = new List<HandObj>();
            foreach (var line in _lines)
            {
                var split = line.Split(' ');
                handList.Add(new HandObj(split[0], int.Parse(split[1]), part: 1));
            }

            return Calculate(handList, cardOrder);
        }

        internal static int Part2()
        {
            string cardOrderPart2 = "J23456789TQKA";
            var handList = new List<HandObj>();
            foreach (var line in _lines)
            {
                var split = line.Split(' ');
                handList.Add(new HandObj(split[0], int.Parse(split[1]), part: 2));
            }
            return Calculate(handList, cardOrderPart2);
        }

        private static int Calculate(List<HandObj> handList, string cardOrder)
        {
            int sum = 0;

            // Group the list of hands by their hand class
            var handClassGrouped = handList
                .GroupBy(h => h.HandClass)
                .Select(g => g.ToList())
                .OrderBy(x => x.First().HandClass)
                .ToList();

            var fullySortedList = new List<HandObj>();

            // Sort the hands within their hand class
            foreach (var handClass in handClassGrouped)
            {
                var sortedHandClass = handClass
                    .OrderBy(x => cardOrder.IndexOf(x.Hand[0]))
                    .ThenBy(x => cardOrder.IndexOf(x.Hand[1]))
                    .ThenBy(x => cardOrder.IndexOf(x.Hand[2]))
                    .ThenBy(x => cardOrder.IndexOf(x.Hand[3]))
                    .ThenBy(x => cardOrder.IndexOf(x.Hand[4]))
                    .ToList();
                fullySortedList.AddRange(sortedHandClass);
            }

            // Calculate answer
            for (int i = 0; i < fullySortedList.Count; i++)
            {
                var thisHand = fullySortedList[i];
                sum += thisHand.Bid * (i + 1);
            }
            return sum;
        }

        internal class HandObj
        {
            internal string Hand { get; init; }
            internal int Bid { get; init; }
            internal int? Rank { get; set; }

            /// <summary>
            /// Class of the hand, high card = 0, five of a kind = 6
            /// </summary>
            internal int HandClass { get; init; }

            public HandObj(string hand, int bid, int part)
            {
                Hand = hand;
                Bid = bid;
                HandClass = part == 1 ? CalculateHandClass() : CalculateHandClassPart2();
            }

            private int CalculateHandClass()
            {
                var count = Hand
                    .GroupBy(c => c)
                    .Select(g => g.Count())
                    .OrderByDescending(li => li)
                    .ToList();

                // If checks ordered by likelihood
                if (count[0] == 1) return 0;
                if (count[0] == 2)
                {
                    if (count[1] == 2) return 2; // 2 Pair
                    else return 1; // Pair
                }
                if (count[0] == 3)
                {
                    if (count[1] == 2) return 4; // Full House
                    else return 3; // 3 of a kind
                }
                if (count[0] == 4) return 5; // Four of a kind
                if (count[0] == 5) return 6; // Five of a kind

                throw new ApplicationException();
            }

            private int CalculateHandClassPart2()
            {
                var numJokers = Hand.Where(c => c == 'J').Count();
                if (numJokers == 5) return 6;

                var noJkHand = Hand.Replace("J", "");

                // Organise the hand without Jokers
                var count = noJkHand
                    .GroupBy(c => c)
                    .Select(g => g.Count())
                    .OrderByDescending(li => li)
                    .ToList();

                // Add jokers to the strongest element
                count[0] += numJokers;

                // If checks ordered by likelihood
                if (count[0] == 1) return 0;
                if (count[0] == 2)
                {
                    if (count[1] == 2) return 2; // 2 Pair
                    else return 1; // Pair
                }
                if (count[0] == 3)
                {
                    if (count[1] == 2) return 4; // Full House
                    else return 3; // 3 of a kind
                }
                if (count[0] == 4) return 5; // Four of a kind
                if (count[0] == 5) return 6; // Five of a kind

                throw new ApplicationException();
            }
        }
    }
}
    