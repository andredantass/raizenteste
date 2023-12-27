export class UserResponse {
  id: string = "";
  email: string = "";
  name: string = "";
  secondName: string = "";
  document: string = "";
  nickname: string = "";
  password: string = "";
  address: Address = new Address();
}
export class Address {
  logradouro: string = "";
  bairro: string = "";
  uf: string = "";
  localidade: string = "";
  city: string = "";
  cep: string = "";
}
