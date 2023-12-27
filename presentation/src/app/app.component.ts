import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { UserRequest } from '../model/userRequest';
import { UserResponse } from '../model/userResponse';
import { UserService } from '../services/userService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  userform: FormGroup;
  users: Array<UserResponse> = new Array<UserResponse>();
  userEdit: UserResponse = new UserResponse();
  isEditing: boolean = false;
  buttonValue = "Cadastrar";

  ngOnInit() {
    this.loadUsers();
  }
  constructor(private service: UserService) {
    this.userform = new FormGroup({
      name: new FormControl(null, [Validators.required]),
      secondname: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      nickname: new FormControl({ value: '', disabled: false }),
      document: new FormControl(null, [Validators.required, Validators.maxLength(11)]),
      password: new FormControl({ value: '', disabled: false }),
      zipcode: new FormControl(null, [Validators.required, Validators.maxLength(8)])
    })
  }

  resetForm() {
    this.userform.reset();
    this.buttonValue = "Cadastrar";
  }
  loadUsers() {
    this.service.getAllUsers().subscribe((result) => {
      this.users = result;
    });
  }
  deleteUser(user: UserResponse) {

    Swal.fire({
      title: "Você quer mesmo deletar este usuário?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Sim",
      denyButtonText: `Não`
    }).then((result) => {
      if (result.isConfirmed) {
        this.service.deleteUser(user.id).subscribe((result) => {
          this.loadUsers();

          this.resetForm();

        })
        Swal.fire({
          title: "Usuário excluido com sucesso!",
          text: "Ok",
          icon: "success"
        });
      } else if (result.isDenied) {

      }
    });
  }
  editUser(user: UserResponse) {
    this.buttonValue = "Atualizar";
    this.userEdit = user;
    this.isEditing = true;
  }
  registerUser() {

    if (this.userform.valid) {
      const request = new UserRequest();
      request.name = this.userform?.get('name')?.value ;
      request.secondName = this.userform?.get('secondname')?.value;
      request.email = this.userform?.get('email')?.value;
      request.nickname =  this.userform?.get('nickname')?.value;
      request.password = this.userform?.get('password')?.value;
      request.zipcode = this.userform?.get('zipcode')?.value;
      request.document = this.userform?.get('document')?.value;

      if (this.isEditing) {
        request.id = this.userEdit.id;

        this.service.updateUser(request).subscribe(result => {
          this.loadUsers();
          this.isEditing = false;
          this.buttonValue = "Cadastrar";
          this.userEdit = new UserResponse();
        }, error => console.error(error));

        Swal.fire({
          title: "Usuário Atualizado com sucesso!",
          text: "Ok",
          icon: "success"
        });
      }
      else {
        this.service.registerUser(request).subscribe(result => {
          this.loadUsers();
          this.resetForm();
        }, error => console.error(error));

        Swal.fire({
          title: "Usuário Cadastrado com sucesso!",
          text: "Ok",
          icon: "success"
        });
      }

    }
    else {
      this.userform.markAllAsTouched();
    }

  }

}
