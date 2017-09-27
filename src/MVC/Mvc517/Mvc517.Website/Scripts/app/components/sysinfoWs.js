var app = new Vue({
    el: '#app',
    data: {
        sysinfo: {}
    },
    methods: {
        getSysInfoJsonStr: function () {
            var vm = this;

            axios.post('../Webservice/WsSysInfo.asmx/GetJsonStr').then(function (response) {

                console.log(response.data);

                if (response.data.hasOwnProperty("d")) {
                    console.log("has d");
                    vm.sysinfo = JSON.parse(response.data.d);
                }
                else {
                    console.log("no d");
                    vm.sysinfo = JSON.parse(response.data);
                }
            }, function (error) {
                console.log(error.statusText);
            });
        },

        getSysInfoJsonObj: function () {
            var vm = this;

            axios.post('../Webservice/WsSysInfo.asmx/GetJsonObj', {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                vm.sysinfo = response.data.d;
            }, function (error) {
                console.log(error.statusText);
            });
        },

        getSysInfoXml: function () {
            var vm = this;

            axios.get('../Webservice/WsSysInfo.asmx/GetXml')
                .then(function (response) {

                    let xml = response.data;
                    console.log(xml);

                    let parser = new DOMParser();
                    xmlDoc = parser.parseFromString(xml, "text/xml");

                    let title =
                        xmlDoc.getElementsByTagName("Title")[0].childNodes[0].nodeValue;
                    let year =
                        xmlDoc.getElementsByTagName("Year")[0].childNodes[0].nodeValue;
                    let author =
                        xmlDoc.getElementsByTagName("Author")[0].childNodes[0].nodeValue;

                    vm.sysinfo = {
                        Title: title,
                        Year: year,
                        Author: author
                    };

                }, function (error) {
                    console.log(error.statusText);
                });
        }
    },
    mounted: function () {
        //this.getSysInfoXml();
        //this.getSysInfoJsonStr();
        this.getSysInfoJsonObj();
    }
})