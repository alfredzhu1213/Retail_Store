<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="EduZY.Web.Main.Index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=Edeg,chrome=1">
    <link href="MainCss/layout.css" rel="stylesheet">
    <link href="MainCss/home.css" rel="stylesheet">
</head>
<body>
    <div class="wrapper" style="background:White; margin-top:20px">
        <div id="content" class="clearfix">
            <div class="left">
                <div class="top-sale">
                    <h3>
                        畅销商品排行</h3>
                    <ol>
                        <li><i>1</i><span>上好佳天然薯片香辣味70g</span><em>25.00</em></li>
                        <li><i>2</i><span>鹰金钱金奖豆鼓鲮鱼227g</span><em>11.00</em></li>
                        <li><i>3</i><span>王八盒子</span><em>6.00</em></li>
                        <li><i>4</i><span>硬盒中华</span><em>2.00</em></li>
                        <li><i>5</i><span>芙蓉王包</span><em>2.00</em></li>
                        <li><i>6</i><span>太平加钙奶盐梳打饼100g</span><em>2.00</em></li>
                        <li><i>7</i><span>徐福记蛋酥沙琪玛38g</span><em>1.00</em></li>
                        <li><i>8</i><span>康师傅美味酥奶油椰子味饼干</span><em>1.00</em></li>
                        <li><i>9</i><span>170G蓝菲鸡蛋卷</span><em>1.00</em></li>
                        <li><i>10</i><span>老乡花生</span><em>1.00</em></li>
                    </ol>
                </div>
            </div>
            <!--left panel if need-->
            <!--right panel if need-->
            <div class="main  no-bg">
                <h2>
                    首页
                </h2>


       
                <div class="cube-box blue" field="NearIncomeData">
                    <h3>
                        销售</h3>
                    <ul class="bg">
                        <li>今天：<span><span dataname="Today" class="big">0.00</span>元</span></li>
                        <li>昨天：<span><span dataname="Yesterday">0.00</span>元</span></li>
                    </ul>
                    <ul>
                        <li>本周：<span><span dataname="LastWeek">0.00</span>元</span></li>
                        <li>本月：<span><span dataname="LastMonth">0.00</span>元</span></li>
                    </ul>
                </div>
                <div class="cube-box green  fl-right" field="NearPromotionData">
                    <h3>
                        毛利</h3>
                    <ul class="bg">
                        <li>今天：<span><span dataname="Today" class="big">0.00</span>元</span></li>
                        <li>昨天：<span><span dataname="Yesterday">0.00</span>元</span></li>
                    </ul>
                    <ul>
                        <li>本周：<span><span dataname="LastWeek">0.00</span>元</span></li>
                        <li>本月：<span><span dataname="LastMonth">0.00</span>元</span></li>
                    </ul>
                </div>
                <div class="cube-box orange" field="NearStockData">
                    <h3>
                        库存</h3>
                    <ul class="bg">
                        <li>库存金额：<span class="alone"><span dataname="Amount" class="big">0</span>元</span></li>
                    </ul>
                </div>
                <div class="cube-box violet fl-right" field="NearPurchaseInData">
                    <h3>
                        采购</h3>
                    <ul class="bg">
                        <li>本周：<span class="alone"><span dataname="LastWeek" class="big">0.00</span>元</span></li>
                    </ul>
                    <ul>
                        <li>本月：<span><span dataname="LastMonth">0.00</span>元</span></li>
                        <li>最近三个月：<span><span dataname="LastThreeMonth">0</span>元</span></li>
                    </ul>
                </div>
          
            </div>
        </div>
    </div>
</body>
</html>
