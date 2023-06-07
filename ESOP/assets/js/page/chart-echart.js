$(function (e) {
    'use strict'

    /* Donut Chart */
    if($('.donut-chart').length != 0){
        var chart = document.getElementById('echart_donut');
        var donutChart = echarts.init(chart);
    }

    donutChart.setOption({
        tooltip: {
            trigger: "item",
            formatter: "{a} <br/>{b} : {c} ({d}%)"
        },
        title:{
            text:"Total Grant",
            subtext:"50,000",
            left: "center",
            top: "center",
            verticalAlign: "center",
            dockInsidePlotArea: true,
            textStyle: {
                fontSize: 16,
                color: "#000",
                fontWeight: "bolder"
              },
              subtextStyle: {
                fontSize: 18,
                color:"#000",
                fontWeight: "bolder"
              }
        },
        
        calculable: !0,
        
        toolbox: {
            show: !0,
            feature: {
                magicType: {
                    show: !0,
                    type: ["pie", "funnel"],
                    option: {
                        funnel: {
                            x: "25%",
                            width: "80%",
                            funnelAlign: "center",
                            max: 1548
                        }
                    }
                },
                restore: {
                    show: !0,
                    title: "Restore"
                },
                saveAsImage: {
                    show: !0,
                    title: "Save Image"
                }
            }
        },
        series: [{
            name: "",
            type: "pie",
            radius: ["55%", "80%"],
            itemStyle: {
                normal: {
                    label: {
                        show: !0
                    },
                    labelLine: {
                        show: !0
                    }
                },
                emphasis: {
                    label: {
                        show: !0,
                        position: "center",
                        textStyle: {
                            fontSize: "18",
                            fontWeight: "normal",
                            fontcolor: "black"
                        }
                    }
                }
            },
            data: [{
                value: 20000,
                name: "Vesting"
            }, {
                value: 5000,
                name: "Exercised"
            }, {
                value: 10000,
                name: "Sale"
            }, {
                value: 5000,
                name: "Total Lapsed"
            },
            {
                value: 10000,
                name: "Stocks in Hand"
            }],
            color: ['#E67E22', '#00dfce', '#fcbe06', '#fd625e', '#1c7b99', '#1c7b59']
        }]
    });

});

