

<template>
<div class="container-fluid" >
      <div class="row">
        <div class="col">
          <div class="text-center bg">
            <h3 class="text-uppercase">Bookkeeping</h3>
          </div>
        </div>
      </div>
      <div class="row">
        <div class="col-2 bg">
          <ul class="list-group">
            <li class="list-group-item bg"><a href="#" class="nav-link" style="color: white">Dashboard</a></li>
            <li class="list-group-item bg" ><a href="#" class="nav-link" style="color: white">Income</a></li>
            <li class="list-group-item bg"><a href="#" class="nav-link" style="color: white">Expense</a></li>
            <li class="list-group-item bg" ><a href="#" class="nav-link" style="color: white">Reconciliation</a></li>
          </ul>
        </div>
        <div class="col-10">
          <div class="col-12">
            <div class="dropdown mb-2">
             
               <h6> Choose Year </h6>
              
              <div>
                 <select  v-model="selected" id="deptList" @change="onChange($event)">
                <option v-for="year in yearList" v-bind:value="year.year">
                  {{year.year}}
                </option>
                </select>  
              </div>
            </div>
          </div>
          <div class="col-12">
            <table class="table table-bordered table-sm">
            <thead>
              <tr>
                <th scope="col" colspan="14" class="text-center">Year {{selected}}</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td></td>
                <td></td>
                <td>Jan</td>
                <td>Feb</td>
                <td>Mar</td>
                <td>Apr</td>
                <td>May</td>
                <td>Jun</td>
                <td>Jul</td>
                <td>Aug</td>
                <td>Sep</td>
                <td>Oct</td>
                <td>Nov</td>
                <td>Dec</td>
              </tr>
              <tr v-for="(p,i) in post">
                <td></td>
                <td v-if=" i == 0" class="tds">Income</td>
                <td v-if=" i == 1" class="tds">Cumulative Income</td>
                <td v-if=" i == 2" class="tds">Cost</td>
                <td v-if=" i == 3" class="tds">Cumulative Cost</td>
                <td v-if=" i == 4" class="tds">Result</td>
                <td>{{p.January ?? 0}}</td>
                <td >{{p.February ?? 0}}</td> 
                <td >{{p.March ?? 0}}</td>
                <td>{{p.April ?? 0}}</td >
                <td >{{p.May ?? 0}}</td>
                <td >{{p.June ?? 0}}</td>
                <td >{{p.July ?? 0}}</td>
                <td >{{p.August ?? 0}}</td>
                <td>{{p.September ?? 0}}</td>
                <td>{{p.October ?? 0}}</td>
                <td>{{p.November ?? 0}}</td>
                <td>{{p.December ?? 0}}</td>
              </tr>
            </tbody>
          </table>
          </div>
          <br>
           <div class="col-12">
            <table class="table table-bordered table-sm">
            <thead>
              <tr>
                <th scope="col" colspan="14" class="text-center">Reconciliation</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td></td>
                <td></td>
                <td>Jan</td>
                <td>Feb</td>
                <td>Mar</td>
                <td>Apr</td>
                <td>May</td>
                <td>Jun</td>
                <td>Jul</td>
                <td>Aug</td>
                <td>Sep</td>
                <td>Oct</td>
                <td>Nov</td>
                <td>Dec</td>
              </tr>
              <tr v-for="(p,i) in Reconciliation">
                <td ></td>
                <td class="tds" v-if="p.StatusId == 1">Income Type {{p.TypeId}}</td>
                <td class="tds" v-if="p.StatusId == 2">Expense Type {{p.TypeId}}</td>
                <td><input type="text" name="" v-model="p.January" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'January')"></td>
                <td ><input type="text" name="" v-model="p.February" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'February')"></td> 
                <td ><input type="text" name="" v-model="p.March" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'March')"></td>
                <td ><input type="text" name="" v-model="p.April" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'April')"></td >
                <td ><input type="text" name="" v-model="p.May" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'May')"></td>
                <td ><input type="text" name="" v-model="p.June" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'June')"></td>
                <td ><input type="text" name="" v-model="p.July" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'July')"></td>
                <td ><input type="text" name="" v-model="p.August" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'August')"></td>
                <td ><input type="text" name="" v-model="p.September" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'September')"></td>
                <td ><input type="text" name="" v-model="p.October" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'October')"></td>
                <td ><input type="text" name="" v-model="p.November" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'November')"></td>
                <td ><input type="text" name="" v-model="p.December" min="0" class="col-md-12 form-control" @keyup="submit($event,i,'December')"></td>
              </tr>
               <tr>
                <td></td>
                <td class="tds">Reconciliation Result</td>
                <td>{{totalQuantity("January")}}</td>
                <td >{{totalQuantity("February")}}</td> 
                <td >{{totalQuantity("March")}}</td>
                <td>{{totalQuantity("April")}}</td>
                <td >{{totalQuantity("May")}}</td> 
                <td >{{totalQuantity("June")}}</td>
                <td>{{totalQuantity("July")}}</td>
                <td >{{totalQuantity("August")}}</td> 
                <td >{{totalQuantity("September")}}</td>
                <td>{{totalQuantity("October")}}</td>
                <td >{{totalQuantity("November")}}</td>
                <td>{{totalQuantity("December")}}</td>
              </tr>
                 <tr>
                <td></td>
                <td class="tds">Final Result</td>
                <td>{{totalQuantity("January") + (post[4]?.January)}}</td>
                <td >{{totalQuantity("February") + (post[4]?.February) }}</td> 
                <td >{{totalQuantity("March") + (post[4]?.March)}}</td>
                <td>{{totalQuantity("April") + (post[4]?.April ) }}</td>
                <td >{{totalQuantity("May") + (post[4]?.May )}}</td> 
                <td >{{totalQuantity("June") + (post[4]?.June) }}</td>
                <td>{{totalQuantity("July") + (post[4]?.July) }}</td>
                <td >{{totalQuantity("August") + (post[4]?.August ) }}</td> 
                <td >{{totalQuantity("September") + (post[4]?.September) }}</td>
                <td>{{totalQuantity("October")  + (post[4]?.October )}}</td>
                <td >{{totalQuantity("November") + (post[4]?.November )}}</td>
                <td>{{totalQuantity("December") + + (post[4]?.December)}}</td>
              </tr>
                  <tr>
                <td></td>
                <td class="tds">Cumulative Final Result</td>
                <td>{{CumulativeResults[0]}}</td>
                <td >{{CumulativeResults[1] }}</td> 
                <td >{{CumulativeResults[2] }}</td> 
                <td >{{CumulativeResults[3]}}</td>
                <td>{{ CumulativeResults[4]}}</td>
                <td >{{CumulativeResults[5]}}</td> 
                <td >{{ CumulativeResults[6]}}</td>
                <td>{{ CumulativeResults[7]}}</td>
                <td >{{CumulativeResults[8] }}</td> 
                <td >{{ CumulativeResults[9]}}</td>
                <td>{{CumulativeResults[10]}}</td>
                <td >{{CumulativeResults[11]}}</td>
              </tr>
            </tbody>
          </table>
          <button  @click="SaveData()" class="col-md-2 btn btn-success  mb-4" style="float:right;width: 80px;">Save</button>
          </div>
        </div>
      </div>
    </div>

</template>
<script type="text/javascript">
import axios from 'axios';
import Toaster from '@meforma/vue-toaster';
export default {

  data() {
    return {
      post:[],
      CumulativeResults: [],
      Reconciliation: [],
      item:  [
        {"Name" : "Income","Jan": 300,"Feb": 500,"Mar":400,"Apr":0,"May": 300,"Jun":70,"Jul":0,"Aug": 300,"Sep":70,"Oct":0,"Nov": 300,"Dec":70},
        {"Name" : "Commulative Income","Jan": 300,"Feb": 500,"Mar":400,"Apr":0,"May": 300,"Jun":70,"Jul":0,"Aug": 300,"Sep":70,"Oct":0,"Nov": 300,"Dec":70},
        {"Name": "Cost","Jan": 300,"Feb": 500,"Mar":400,"Apr":0,"May": 300,"Jun":70,"Jul":0,"Aug": 300,"Sep":70,"Oct":0,"Nov": 300,"Dec":70}
      ],
      selected : 2022,
      yearList : [
                { year: 2019},
                { year: 2020},
                { year: 2021},
                { year: 2022},
                { year: 2023}
                ]
    };
    
    
  },

  methods: {

      submit(e,index,col)
      {
               
               if(col !=undefined)
               {
                  this.Reconciliation[index][col] = (isNaN(e.target.value) || e.target.value=='') == true ? null : Number(e.target.value);
                  this.renderCumulativeSum();
                }
              
      },
      renderCumulativeSum ()
      {
              let Result = [];
               Result.push(this.totalQuantity("January") + (this.post[4]?.January ));
                Result.push(this.totalQuantity("February") + (this.post[4]?.February));
                Result.push(this.totalQuantity("March") + (this.post[4]?.March));
                Result.push(this.totalQuantity("April") + (this.post[4]?.April) );
                Result.push(this.totalQuantity("May") + (this.post[4]?.May ) );
                Result.push(this.totalQuantity("June") + (this.post[4]?.June) );
                Result.push(this.totalQuantity("July") + (this.post[4]?.July) );
                Result.push(this.totalQuantity("August") + (this.post[4]?.August ) );
                Result.push(this.totalQuantity("September") + (this.post[4]?.September ));
                Result.push(this.totalQuantity("October")  + (this.post[4]?.October));
                Result.push(this.totalQuantity("November") + (this.post[4]?.November));
                Result.push(this.totalQuantity("December") + + (this.post[4]?.December));
                this.CumulativeResults =  Result.map((sum => value => sum += value)(0));
      },
      onChange(event) {
            
            this.getDataOnChange();
            this.getInitialData(); 
            this.totalQuantity("January");
      },
      SaveData ()
      {
        this.SaveReconciliationData();
      },
      getDataOnChange ()
      {
         axios.get("https://localhost:5001/IncomeVsExpense/GetIncomeVsExpenseData?year="+this.selected).then( response=> {
            
            this.post = response.data;
             if(this.Reconciliation.length > 0 && this.post.length > 0){
                this.renderCumulativeSum();
             }

            }).catch( error => {
              console.log(error);
            })
            
      },
       totalQuantity(v){
          
            return this.Reconciliation.reduce(function(total, item){

              return  item.StatusId == 1 ? total + (item[v] ?? 0)  : total - (item[v]?? 0); 
            },0);
          }, 
     getInitialData ()
      {
          axios.get("https://localhost:5001/Reconciliation/GetInitializeReconciliationData?year="+this.selected).then( response=> {
            this.Reconciliation = response.data;
            if(response.data.length > 0 && this.post.length > 0)
            {
              this.renderCumulativeSum();
            }
            }).catch( error => {
              console.log(error);
            }) 
      },
      SaveReconciliationData ()
      {
         axios.post("https://localhost:5001/Reconciliation/Save",this.Reconciliation).then( response=> {
            
            if(response.data.Success)
            {
              this.$toast.success("saved successfully.", { position: "top",});
              this.getInitialData();
            }
            }).catch( error => {
              this.$toast.error("error in save", { position: "top",});
              console.log(error);
            }) 
      }
  },
  created()
  {
    this.onChange();
    
  },
 mounted(){
    
 }
};
</script>
<style>
@import './assets/base.css';
@import'../node_modules/bootstrap/dist/css/bootstrap.css';

.tds{
  width: 17%;
}
.bg{
  background: #72b772;
}
</style>
