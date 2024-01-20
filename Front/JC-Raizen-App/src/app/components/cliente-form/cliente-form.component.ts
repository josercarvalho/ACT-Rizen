import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Cliente } from 'src/app/pages/models/Clientes';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Cliente>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosCliente: Cliente | null = null;

  cepField = new FormControl;

  clienteForm!: FormGroup;

  constructor(private clienteService: ClienteService, private router: Router) { }

  ngOnInit(): void {

    this.clienteForm = new FormGroup({
      id: new FormControl(this.dadosCliente ? this.dadosCliente.id : 0),
      nome: new FormControl(this.dadosCliente ? this.dadosCliente.nome : '', [Validators.required]),
      email: new FormControl(this.dadosCliente ? this.dadosCliente.email : '', [Validators.required]),
      dataNascimento: new FormControl(this.dadosCliente ? new Date(this.dadosCliente.dataNascimento).toLocaleDateString("pt-BR") : '', [Validators.required]),
      cep: new FormControl(this.dadosCliente ? this.dadosCliente.cep : '', [Validators.required]),
      logradouro: new FormControl(this.dadosCliente ? this.dadosCliente.logradouro : '', [Validators.required]),
      localidade: new FormControl(this.dadosCliente ? this.dadosCliente.localidade : '', [Validators.required]),
      bairro: new FormControl(this.dadosCliente ? this.dadosCliente.bairro : '', [Validators.required]),
      complemento: new FormControl(this.dadosCliente ? this.dadosCliente.complemento : ''),
      uf: new FormControl(this.dadosCliente ? this.dadosCliente.uf : '', [Validators.required]),

    });
  }
  get nome() {
    return this.clienteForm.get('nome')!;
  }

  BuscarCep() {
    let value = this.cepField.value;

    this.clienteService.BuscaCep(value).subscribe((data) => {
      const dados = data;

      let cep = dados.cep?.replace("-","")

      this.clienteForm = new FormGroup({
        id: new FormControl(this.dadosCliente ? this.dadosCliente.id : 0),
        nome: new FormControl(this.dadosCliente ? this.dadosCliente.nome : '', [Validators.required]),
        email: new FormControl(this.dadosCliente ? this.dadosCliente.email : '', [Validators.required]),
        dataNascimento: new FormControl(this.dadosCliente ? new Date(this.dadosCliente.dataNascimento).toLocaleDateString("pt-BR") : '', [Validators.required]),
        cep: new FormControl(cep, [Validators.required]),
        logradouro: new FormControl(dados.logradouro, [Validators.required]),
        localidade: new FormControl(dados.localidade, [Validators.required]),
        bairro: new FormControl(dados.bairro, [Validators.required]),
        complemento: new FormControl(dados.complemento),
        uf: new FormControl(dados.uf, [Validators.required]),
      })
    });
  }

  submit() {

    console.log(this.clienteForm.value)

    this.onSubmit.emit(this.clienteForm.value);
  }
}
