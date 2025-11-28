using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeGotao.Core.Data;
using ZeGotao.DTO;
using ZeGotao.Models;


namespace ZeGotao.BLL
{
    public class UsuarioBLL
    {
      
            private readonly ZeGotaoContext _context;

            public UsuarioBLL(ZeGotaoContext context)
            {
                _context = context;
            }

            public List<UsuarioDTO> GetAll()
            {
                return _context.Usuario
                    .Select(u => new UsuarioDTO
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Cpf = u.Cpf,
                        Telefone = u.Telefone,
                        Endereco = u.Endereco,
                        DataNascimento = u.DataNascimento,
                        TipoUsuarioId = u.TipoUsuarioId,
                        Ativo = u.Ativo
                    }).ToList();
            }

            public UsuarioDTO? Get(int id)
            {
                var u = _context.Usuario.Find(id);
                if (u == null) return null;

                return new UsuarioDTO
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Cpf = u.Cpf,
                    Telefone = u.Telefone,
                    Endereco = u.Endereco,
                    DataNascimento = u.DataNascimento,
                    TipoUsuarioId = u.TipoUsuarioId,
                    Ativo = u.Ativo
                };
            }

            public void Add(UsuarioDTO dto)
            {
                var u = new Usuario
                {
                    Nome = dto.Nome,
                    Email = dto.Email,
                    Cpf = dto.Cpf,
                    Telefone = dto.Telefone,
                    Endereco = dto.Endereco,
                    DataNascimento = dto.DataNascimento,
                    TipoUsuarioId = dto.TipoUsuarioId,
                    Ativo = dto.Ativo,
                    Senha = "123"
                };

                _context.Usuario.Add(u);
                _context.SaveChanges();
            }

            public void Update(UsuarioDTO dto)
            {
                var u = _context.Usuario.Find(dto.IdUsuario);
                if (u == null) return;

                u.Nome = dto.Nome;
                u.Email = dto.Email;
                u.Cpf = dto.Cpf;
                u.Telefone = dto.Telefone;
                u.Endereco = dto.Endereco;
                u.DataNascimento = dto.DataNascimento;
                u.TipoUsuarioId = dto.TipoUsuarioId;
                u.Ativo = dto.Ativo;

                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var u = _context.Usuario.Find(id);
                if (u == null) return;

                _context.Usuario.Remove(u);
                _context.SaveChanges();
            }
        }
    }

