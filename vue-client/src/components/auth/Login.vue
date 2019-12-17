<template>
    <div>
        <p>Log in page</p>
        <form @submit.prevent="login" class="form col-sm-3 offset-md-4">
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-default">User Name</span>
                </div>
                <input type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" v-model="username">
            </div>
            <div class="input-group">
                <div class="input-group-prepend">
                    <span class="input-group-text" id="inputGroup-sizing-default">Password</span>
                </div>
                <input type="password" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" v-model="password">
            </div>
            <button type="submit" class="btn btn-primary">Login</button>
        </form>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import { Component, Emit, Prop, Watch } from 'vue-property-decorator';
import {authService} from './auth.service';
import { LoginModel } from './loginModel';
@Component({})
export default class Login extends Vue {
    public username: string = '';
    public password: string = '';

    public login(): void{
        const loginRequest: LoginModel = {
            'username': this.username,
            'password': this.password,
        }
        authService.logIn(loginRequest);
    }
}
</script>
