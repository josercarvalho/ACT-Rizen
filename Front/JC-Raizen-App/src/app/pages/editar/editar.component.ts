import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Cliente } from '../models/Clientes';
import { ClienteService } from 'src/app/services/cliente.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})

export class EditarComponent implements OnInit {

  btnAcao = "Editar";
  btnTitulo = "Editar Cliente!";
  cliente!: Cliente;

  constructor(
    private clienteService: ClienteService,
    private router: Router,
    private route: ActivatedRoute,
    public matSnackBar: MatSnackBar) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.clienteService.GetCliente(id).subscribe((data) => {
      this.cliente = data;

    });
  }

  async editCliente(cliente: Cliente) {

    this.clienteService.EditCliente(cliente).subscribe(data => {
      this.matSnackBar.open("Salvo com sucesso!", "", {
        duration: 5000
      })
      this.router.navigate(['/']);
    })
  }
}
