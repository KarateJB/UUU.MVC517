Vue.component('create-comp', {
    template: `<div class="form-group">
                    <label class="control-label col-md-2" for="Title">名稱</label>
                    <div class="col-md-10">
                        <input class="form-control text-box single-line" name="Title" type="text" value="" />
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2" for="Year">年分</label>
                    <div class="col-md-10">
                        <input class="form-control text-box single-line" name="Year" type="number" value="" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2" for="Composer">作曲家</label>
                    <div class="col-md-10">
                        <input class="form-control text-box single-line" name="Composer" type="text" value="" />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2" for="Comment_Subject">Subject</label>
                    <div class="col-md-10">
                        <textarea cols="20" data-val-length-max="200" name="Comment.Subject" rows="2">
                        </textarea>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <input type="submit" value="Create" class="btn btn-default" />
                    </div>
                </div>
             </div>          </div>`
});


Vue.component('index-comp', {
    props: ['operas'],
    template: `<div>
        <table class="table">
            <tr>
                <th>名稱</th>
                <th>年分</th>
                <th>作曲家</th>
                <th></th>
            </tr>
            <tr v-for="opera in operas">
                <input type="hidden" value="{{ opera.Id }}" />
                <td>{{ opera.Title }}</td>
                <td>{{ opera.Year }}</td>
                <td>{{ opera.Composer }}</td>
                <td>
                    <a href="{{ opera.Id }}">Edit</a> |
                    <a href="/Home/Delete/{{ Id }}">Delete</a>
                </td>
            </tr>
        </table>
    </div>`
});


var app = new Vue({
    el: '#app',
    data: {
        operas: [],
        createUri: "/Rest/Create/",
        editUri: "/Rest/Edit/",
        deleteUri: "/Rest/Delete/",

    },
    methods: {
        getOperas: function () {
            return axios.get('http://localhost:36321/api/RestApi/Get');
        }
    },
    mounted: function () {
        var vm = this;

        vm.getOperas().then(response => {
            vm.operas = response.data;
            console.log(vm.operas);
        });
    }
})